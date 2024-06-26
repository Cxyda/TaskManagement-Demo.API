﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TaskManagementDemo.Domain.Entities;
using TaskManagementDemo.Domain.Exceptions;

namespace TaskManagementDemo.Application.Users.Commands.UnassignUserRoleCommand;

public class UnassignUserRoleCommandHandler(
    ILogger<UnassignUserRoleCommandHandler> logger,
    UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager) : IRequestHandler<UnassignUserRoleCommand>
{
    public async Task Handle(UnassignUserRoleCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Unassigning role {RoleName} from user {UserEmail}", request.RoleName, request.UserEmail);

        var user = await userManager.FindByEmailAsync(request.UserEmail)
                   ?? throw new NotFoundException(nameof(User), request.UserEmail); ;

        var role = await roleManager.FindByNameAsync(request.RoleName)
                   ?? throw new NotFoundException(nameof(IdentityRole), request.RoleName);

        await userManager.RemoveFromRoleAsync(user, role.Name!);
    }
}