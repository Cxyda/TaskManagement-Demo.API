using TaskManagementDemo.Domain.Entities;

namespace TaskManagementDemo.Domain.Repositories;

public interface ITaskManagementRepository
{
    Task<IEnumerable<TaskEntity>> GetAllTasksAsync();
    Task<TaskEntity?> GetTaskByIdAsync(int taskId);
    Task<int> CreateAsync(TaskEntity taskEntity);
}