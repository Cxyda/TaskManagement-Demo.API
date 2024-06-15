

using MediatR;

namespace TaskManagementDemo.Application.Tasks.Commands.DeleteTaskCommand;

public class DeleteTaskCommand(int id) : IRequest
{
    public int Id { get; } = id;
}