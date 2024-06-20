using MediatR;
using TaskManagementDemo.Domain.Constants;
using TaskStatus = TaskManagementDemo.Domain.Constants.TaskStatus;

namespace TaskManagementDemo.Application.Tasks.Commands.CreateTaskCommand;

public class CreateTaskCommand : IRequest<int>
{
    public string Title { get; set; } = default!;
    public string? Description { get; set; }

    public TaskStatus Status { get; set; }
    public Priority Priority { get; set; }
    public Complexity Complexity { get; set; }
}