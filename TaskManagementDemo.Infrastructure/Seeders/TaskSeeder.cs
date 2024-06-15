using TaskManagementDemo.Domain.Entities;
using TaskManagementDemo.Infrastructure.Persistence;

namespace TaskManagementDemo.Infrastructure.Seeders;

internal class TaskSeeder(TaskManagementDbContext dbContext) : ITaskSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Tasks.Any())
            {
                var tasks = GetTasks();
                dbContext.Tasks.AddRange(tasks);
                await dbContext.SaveChangesAsync();
            }

        }
    }

    private IEnumerable<TaskEntity> GetTasks()
    {
        var list = new List<TaskEntity>
        {
            new()
            {
                Title = "Task 1",
                Description = "Task 1 Description"
            },
            new()
            {
                Title = "Task 2",
                Description = "Task 2 Description"
            },
            new()
            {
                Title = "Task 3",
                Description = "Task 3 Description"
            }
        };
        return list;
    }
}
