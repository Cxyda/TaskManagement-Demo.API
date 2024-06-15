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
        var taskEntity = await dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == taskId);

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
}