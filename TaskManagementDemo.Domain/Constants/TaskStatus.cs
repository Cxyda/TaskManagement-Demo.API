
namespace TaskManagementDemo.Domain.Constants;

public enum TaskStatus : byte
{
    Backlog = 0,
    Assigned = 1,
    InProgress = 2,
    InReview = 3,
    Blocked = 4,
    /// <summary>
    /// Closed (Won't fix)
    /// </summary>
    Closed = 5,
    /// <summary>
    /// Closed (fixed)
    /// </summary>
    Done = 6
}