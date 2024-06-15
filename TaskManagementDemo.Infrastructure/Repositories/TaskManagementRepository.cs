
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using TaskManagementDemo.Domain.Entities;
using TaskManagementDemo.Domain.Repositories;
using TaskManagementDemo.Infrastructure.Persistence;

namespace TaskManagementDemo.Infrastructure.Repositories;

internal class TaskManagementRepository(TaskManagementDbContext dbContext) : ITaskManagementRepository
{
    public async Task<IEnumerable<TaskEntity>> GetAllTasks()
    {
        var tasks = await dbContext.Tasks.ToListAsync();
        return tasks;
    }

    public async Task<TaskEntity?> GetTaskById(int taskId)
    {
        var taskEntity = await dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == taskId);

        return taskEntity;
    }
}