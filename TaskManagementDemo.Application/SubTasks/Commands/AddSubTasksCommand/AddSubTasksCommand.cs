using MediatR;

namespace TaskManagementDemo.Application.SubTasks.Commands.AddSubTasksCommand
{
    public class AddSubTasksCommand(List<int> subTaskIds) : IRequest
    {
        public List<int> SubTaskIds { get; } = subTaskIds;
        public int ParentTaskId { get; set; } = default!;

    }
}
