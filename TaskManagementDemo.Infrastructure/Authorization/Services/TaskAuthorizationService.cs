using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TaskManagementDemo.Application.Users;
using TaskManagementDemo.Domain.Constants;
using TaskManagementDemo.Domain.Entities;
using TaskManagementDemo.Domain.Interfaces;

namespace TaskManagementDemo.Infrastructure.Authorization.Services;

public class TaskAuthorizationService(ILogger<TaskAuthorizationService> logger,
    IUserContext userContext) : ITaskAuthorizationService
{
    public bool Authorize(TaskEntity task, ResourceOperation resourceOperation)
    {
        var user = userContext.GetCurrentUser();
        logger.LogInformation("User: {UserName} [{UserId}] is trying to {Operation} task {RestaurantId}",
            user?.Email, user?.Id, resourceOperation, task.Id);

        if (resourceOperation is ResourceOperation.Read or ResourceOperation.Create)
        {
            logger.LogInformation("Create/read operation - successful authorization");
            return true;
        }

        if (resourceOperation == ResourceOperation.Delete && user!.IsInRole(UserRoles.Admin))
        {
            logger.LogInformation("Admin user, delete operation - successful authorization");
            return true;
        }

        if ((resourceOperation is ResourceOperation.Delete or ResourceOperation.Update) && (user!.IsInRole(UserRoles.Manager) || user!.Id == task.CreatorId))
        {
            logger.LogInformation("Task creator or manager - successful authorization");
            return true;
        }

        return false;

    }
}