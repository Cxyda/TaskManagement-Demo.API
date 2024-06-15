
using MediatR;

namespace TaskManagementDemo.Application.Tasks.GetAllTasksQuery;

public class GetAllTasksQuery : IRequest<IEnumerable<TaskEntityDto>>
{
}