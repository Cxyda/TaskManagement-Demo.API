using TaskManagementDemo.Domain.Entities;
using TaskManagementDemo.Infrastructure.Persistence;

namespace TaskManagementDemo.Infrastructure.Seeders;

public interface ITasksSeeder : IDatabaseSeeder
{
}
internal class TasksSeeder(TaskManagementDbContext dbContext) : ITasksSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Tasks.Any())
            {
                var tasks = GetTasks();
                dbContext.Tasks.AddRange(tasks);
                var parentTask = dbContext.Tasks.First();

                var subTasks = GetSubTasks(parentTask);
                parentTask.SubTasks.AddRange(subTasks);

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
                Title = "Do the laundry",
                Description = "Do the laundry has many sub tasks",
                Complexity = Domain.Constants.Complexity.Medium,
            }

        };
        return list;
    }

    private IEnumerable<TaskEntity> GetSubTasks(TaskEntity parentTask)
    {
        var list = new List<TaskEntity>
        {
            new()
            {
                Title = "Collect dirty clothes",
                Description = "Collect dirty clothes",
                ParentTaskId = parentTask.Id,
                ParentTask = parentTask,
                Complexity = Domain.Constants.Complexity.VeryLow,
            },
            new()
            {
                Title = "Sort cloths",
                Description = "Uhh erm ??!",
                ParentTaskId = parentTask.Id,
                ParentTask = parentTask,
                Complexity = Domain.Constants.Complexity.Medium,
            },
            new()
            {
                Title = "Put cloths into the washing machine & press start",
                Description = "Put cloths into the washing machine & press start",
                ParentTaskId = parentTask.Id,
                ParentTask = parentTask,
                Complexity = Domain.Constants.Complexity.VeryLow,
            },
            new()
            {
                Title = "wait until washing machine is finished",
                Description = "Take a nap",
                ParentTaskId = parentTask.Id,
                ParentTask = parentTask,
                Complexity = Domain.Constants.Complexity.VeryLow,
            },
            new()
            {
                Title = "Collect cloths from washing machine and hang it up",
                Description = "Collect cloths from washing machine and hang it up",
                ParentTaskId = parentTask.Id,
                ParentTask = parentTask,
                Complexity = Domain.Constants.Complexity.Medium,
            }
        };
        return list;
    }
}
