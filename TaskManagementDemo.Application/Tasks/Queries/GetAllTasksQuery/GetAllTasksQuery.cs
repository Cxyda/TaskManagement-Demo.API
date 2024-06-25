
using MediatR;
using TaskManagementDemo.Application.Common;
using TaskManagementDemo.Application.Dtos;
using TaskManagementDemo.Domain.Constants;

namespace TaskManagementDemo.Application.Tasks.Queries.GetAllTasksQuery;

public class GetAllTasksQuery : IRequest<PageResult<TaskEntityDto>>
{
    public string? SearchPhrase { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
}