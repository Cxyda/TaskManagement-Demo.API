using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using TaskManagementDemo.Domain.Constants;
using TaskManagementDemo.Domain.Entities;
using TaskManagementDemo.Domain.Exceptions;
using TaskManagementDemo.Domain.Repositories;
using TaskManagementDemo.Infrastructure.Persistence;

namespace TaskManagementDemo.Infrastructure.Repositories;

internal class TaskManagementRepository(TaskManagementDbContext dbContext, ILogger<TaskManagementRepository> logger) : ITaskManagementRepository
{
    public async Task<IEnumerable<TaskEntity>> GetAllTasksAsync()
    {
        var tasks = await dbContext.Tasks.ToListAsync();
        return tasks;
    }

    public async Task<(IEnumerable<TaskEntity>, int)> GetAllMatchingTasksAsync(string? searchPhrase, int pageSize, int pageNumber, string? sortBy,
        SortDirection sortDirection)
    {
        var baseQuery = GetBaseQuery(searchPhrase, sortBy);

        int totalCount = await baseQuery.CountAsync();

        if (sortBy != null)
        {
            var columnsSelector = new Dictionary<string, Expression<Func<TaskEntity, object>>>()
            {
                {nameof(TaskEntity.Title), r => r.Title!},
                {nameof(TaskEntity.Description), r => r.Description!},
                {nameof(TaskEntity.Status), r => r.Status},
                {nameof(TaskEntity.Complexity), r => r.Complexity},
                {nameof(TaskEntity.Priority), r => r.Priority},
            };

            var selectedColumn = columnsSelector[sortBy];
            baseQuery = sortDirection == SortDirection.Ascending ? baseQuery.OrderBy(selectedColumn) : baseQuery.OrderByDescending(selectedColumn);
        }

        var tasks = await baseQuery
            .Skip(pageSize * pageNumber)
            .Take(pageSize)
            .ToListAsync();

        return (tasks, totalCount);
    }

    private IQueryable<TaskEntity> GetBaseQuery(string? searchPhrase, string? sortBy)
    {
        var searchPhraseLower = searchPhrase?.ToLower();
        byte.TryParse(searchPhrase, out byte searchPhraseValue);

        Expression <Func<TaskEntity, bool>> exp = task => searchPhraseLower == null;
        IQueryable<TaskEntity> baseQuery;
        if (sortBy != null && searchPhraseLower != null)
        {
            if (sortBy.Equals(nameof(TaskEntity.Complexity)))
            {
                exp = task => (int)task.Complexity == searchPhraseValue;
            }
            else if(sortBy.Equals(nameof(TaskEntity.Priority)))
            {
                exp = task => (int)task.Priority == searchPhraseValue;
            }
            else if(sortBy.Equals(nameof(TaskEntity.Status)))
            {
                exp = task => (int)task.Status == searchPhraseValue;
            }
            else if (sortBy.Equals(nameof(TaskEntity.Description)))
            {
                exp = task => task.Description!.ToLower().Contains(searchPhraseLower);
            }
            else if (sortBy.Equals(nameof(TaskEntity.Title)))
            {
                exp = task => task.Title!.ToLower().Contains(searchPhraseLower);
            }
            else
            {
                throw new NotFoundException("SortBy", sortBy);
            }
            baseQuery = dbContext.Tasks.Where(exp);
        }
        else
        {
            baseQuery = dbContext.Tasks.Where(exp);
        }

        return baseQuery;
    }


    public async Task<TaskEntity?> GetTaskByIdAsync(int taskId)
    {
        var taskEntity = await dbContext.Tasks.Include(t =>t.SubTasks)
            .FirstOrDefaultAsync(x => x.Id == taskId);

        return taskEntity;
    }

    public async Task<int> CreateAsync(TaskEntity entity)
    {
        await dbContext.Tasks.AddAsync(entity);
        await dbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TaskEntity entity)
    {
        dbContext.Tasks.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public bool ContainsTasksByIdAll(IEnumerable<int> taskIdCollection)
    {
        foreach (var subTaskId in taskIdCollection)
        {
            var subTask = GetTaskByIdAsync(subTaskId).Result;
            if (subTask == null)
            {
                return false;
            }
        }
        return true;
    }
}