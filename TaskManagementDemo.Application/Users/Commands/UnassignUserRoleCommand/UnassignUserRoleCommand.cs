
using MediatR;

namespace TaskManagementDemo.Application.Users.Commands.UnassignUserRoleCommand;

public class UnassignUserRoleCommand : IRequest
{
    public string UserEmail { get; set; } = default!;
    public string RoleName { get; set; } = default!;
}