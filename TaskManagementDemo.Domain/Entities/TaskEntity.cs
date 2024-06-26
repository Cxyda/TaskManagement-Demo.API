using TaskManagementDemo.Domain.Constants;
using TaskStatus = TaskManagementDemo.Domain.Constants.TaskStatus;

namespace TaskManagementDemo.Domain.Entities;

public class TaskEntity
{
    public int Id { get; set; }
    public string? Title { get; set; } = default!;
    public string? Description { get; set; }

    public TaskStatus Status { get; set; }
    public Priority Priority { get; set; }
    public Complexity Complexity { get; set; }

    public List<TaskEntity> SubTasks { get; set; } = [];

    public int? ParentTaskId { get; set; } // Nullable to allow root tasks
    public TaskEntity? ParentTask { get; set; }

    public string? CreatorId { get; set; } = default!;
}