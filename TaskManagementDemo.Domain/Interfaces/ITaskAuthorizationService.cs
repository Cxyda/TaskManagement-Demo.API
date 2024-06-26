
using TaskManagementDemo.Domain.Constants;
using TaskManagementDemo.Domain.Entities;

namespace TaskManagementDemo.Domain.Interfaces;

public interface ITaskAuthorizationService
{
    bool Authorize(TaskEntity task, ResourceOperation resourceOperation);

}