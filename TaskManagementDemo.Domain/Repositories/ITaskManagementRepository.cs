using TaskManagementDemo.Domain.Entities;

namespace TaskManagementDemo.Domain.Repositories;

public interface ITaskManagementRepository
{
    Task<IEnumerable<TaskEntity>> GetAllTasks();
}