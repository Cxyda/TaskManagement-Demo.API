using System.Security.AccessControl;
using MediatR;

namespace TaskManagementDemo.Application.SubTasks.Commands.DeleteSubTasksCommand;

public class DeleteSubTasksCommand(List<int> subTaskIds) : IRequest<int>, IRequest
{
    public int ParentTaskId { get; set; } = default!;
    public List<int> SubTaskIds { get; } = subTaskIds;

}