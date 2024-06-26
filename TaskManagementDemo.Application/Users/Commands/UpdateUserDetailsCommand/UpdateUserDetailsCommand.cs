using MediatR;

namespace TaskManagementDemo.Application.Users.Commands.UpdateUserDetailsCommand;

public class UpdateUserDetailsCommand : IRequest
{
    public string? Department { get; set; } = default!;
}