using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagementDemo.Application.Dtos;
using TaskManagementDemo.Domain.Entities;
using TaskManagementDemo.Domain.Exceptions;
using TaskManagementDemo.Domain.Repositories;

namespace TaskManagementDemo.Application.Tasks.Queries.GetTaskByIdQuery;

public class GetTaskByIdQueryHandler(ILogger<GetTaskByIdQueryHandler> logger,
    ITaskManagementRepository taskManagementRepository,
    IMapper mapper) : IRequestHandler<GetTaskByIdQuery, TaskEntityDto>
{
    public async Task<TaskEntityDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting TaskEntity by id {RequestId} [{@Request}]", request.Id, request);

        var taskEntity = await taskManagementRepository.GetTaskById(request.Id!.Value)
                   ?? throw new NotFoundException(nameof(TaskEntity), request.Id!.ToString());

        var taskDto = mapper.Map<TaskEntityDto>(taskEntity);

        return taskDto;
    }
}