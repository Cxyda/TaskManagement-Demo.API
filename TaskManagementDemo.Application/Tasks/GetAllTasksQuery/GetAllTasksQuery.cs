
using MediatR;
using TaskManagementDemo.Application.Dtos;

namespace TaskManagementDemo.Application.Tasks.GetAllTasksQuery;

public class GetAllTasksQuery : IRequest<IEnumerable<TaskEntityDto>>
{
}