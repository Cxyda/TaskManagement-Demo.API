using Microsoft.EntityFrameworkCore;
using TaskManagementDemo.Domain.Entities;
using TaskManagementDemo.Domain.Repositories;
using TaskManagementDemo.Infrastructure.Persistence;

namespace TaskManagementDemo.Infrastructure.Repositories;

internal class TaskManagementRepository(TaskManagementDbContext dbContext) : ITaskManagementRepository
{
    public async Task<IEnumerable<TaskEntity>> GetAllTasksAsync()
    {
        var tasks = await dbContext.Tasks.ToListAsync();
        return tasks;
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