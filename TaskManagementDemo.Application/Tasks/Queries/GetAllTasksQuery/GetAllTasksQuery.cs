
using MediatR;
using TaskManagementDemo.Application.Dtos;

namespace TaskManagementDemo.Application.Tasks.Queries.GetAllTasksQuery;

public class GetAllTasksQuery : IRequest<IEnumerable<TaskEntityDto>>
{
}