using MediatR;
using TaskManagementDemo.Application.Dtos;

namespace TaskManagementDemo.Application.Tasks.Queries.GetTaskByIdQuery;

public class GetTaskByIdQuery(int id) : IRequest<TaskEntityDto>
{
    public int? Id { get; } = id;
}