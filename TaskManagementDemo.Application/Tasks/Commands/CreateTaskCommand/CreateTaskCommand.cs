using MediatR;

namespace TaskManagementDemo.Application.Tasks.Commands.CreateTaskCommand;

public class CreateTaskCommand : IRequest<int>
{
    public string Title { get; set; } = default!;
    public string Description { get; set; }
}