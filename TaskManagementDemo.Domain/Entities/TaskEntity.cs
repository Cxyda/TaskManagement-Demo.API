
namespace TaskManagementDemo.Domain.Entities;

public class TaskEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; }

}