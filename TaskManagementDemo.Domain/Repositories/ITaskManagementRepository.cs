using TaskManagementDemo.Domain.Entities;

namespace TaskManagementDemo.Domain.Repositories;

public interface ITaskManagementRepository
{
    Task<int> CreateAsync(TaskEntity entity);

    Task<IEnumerable<TaskEntity>> GetAllTasksAsync();
    Task<TaskEntity?> GetTaskByIdAsync(int taskId);
    Task SaveChangesAsync();

    Task DeleteAsync(TaskEntity entity);

    bool ContainsTasksByIdAll(IEnumerable<int> taskIdCollection);

}