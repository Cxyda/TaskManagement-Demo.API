using MediatR;

namespace TaskManagementDemo.Application.Users.Commands.AssignUserRoleCommand;

public class AssignUserRoleCommand : IRequest
{
    public string UserEmail { get; set; } = default!;
    public string RoleName { get; set; } = default!;
}