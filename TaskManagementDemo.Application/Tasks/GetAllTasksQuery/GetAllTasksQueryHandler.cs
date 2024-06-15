
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagementDemo.Domain.Repositories;

namespace TaskManagementDemo.Application.Tasks.GetAllTasksQuery
{
    internal class GetAllTasksQueryHandler(
        ILogger<GetAllTasksQueryHandler> logger,
        ITaskManagementRepository taskManagementRepository,
        IMapper mapper) 
            : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskEntityDto>>
    {
        public async Task<IEnumerable<TaskEntityDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Requesting all tasks...");

            var allTasks = await taskManagementRepository.GetAllTasks();

            var taskDtos = mapper.Map<IEnumerable<TaskEntityDto>>(allTasks);

            return taskDtos;
        }
    }
}
