
using MediatR;
using TaskManagementDemo.Domain.Constants;
using TaskStatus = TaskManagementDemo.Domain.Constants.TaskStatus;

namespace TaskManagementDemo.Application.Tasks.Commands.UpdateTaskCommand;

public class UpdateTaskCommand : IRequest
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; } = default!;

    public TaskStatus? Status { get; set; } = default!;
    public Priority? Priority { get; set; } = default!;
    public Complexity? Complexity { get; set; } = default!;
}