using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagementDemo.Application.Common;
using TaskManagementDemo.Application.Dtos;
using TaskManagementDemo.Domain.Repositories;

namespace TaskManagementDemo.Application.Tasks.Queries.GetAllTasksQuery
{
    internal class GetAllTasksQueryHandler(
        ILogger<GetAllTasksQueryHandler> logger,
        ITaskManagementRepository taskManagementRepository,
        IMapper mapper)
            : IRequestHandler<GetAllTasksQuery, PageResult<TaskEntityDto>>
    {
        public async Task<PageResult<TaskEntityDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Requesting all tasks...");

            var (matchingTasksAsync, totalCount) = await taskManagementRepository.GetAllMatchingTasksAsync(
                request.SearchPhrase,
                request.PageSize,
                request.PageNumber,
                request.SortBy,
                request.SortDirection);

            var taskDtos = mapper.Map<IEnumerable<TaskEntityDto>>(matchingTasksAsync);

            var result = new PageResult<TaskEntityDto>(taskDtos.ToList(), totalCount, request.PageNumber, request.PageSize);

            return result;
        }
    }
}
