using TaskManagementDemo.Domain.Constants;
using TaskManagementDemo.Domain.Entities;

namespace TaskManagementDemo.Domain.Repositories;

public interface ITaskManagementRepository
{
    Task<int> CreateAsync(TaskEntity entity);

    Task<IEnumerable<TaskEntity>> GetAllTasksAsync();
    Task<(IEnumerable<TaskEntity>, int)> GetAllMatchingTasksAsync(string? searchPhrase, int pageSize, int pageNumber, string? sortBy,
        SortDirection sortDirection);
    Task<TaskEntity?> GetTaskByIdAsync(int taskId);
    Task SaveChangesAsync();

    Task DeleteAsync(TaskEntity entity);

    bool ContainsTasksByIdAll(IEnumerable<int> taskIdCollection);

}