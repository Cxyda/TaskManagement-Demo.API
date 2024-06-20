using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TaskManagementDemo.Domain.Entities;
using TaskManagementDemo.Domain.Exceptions;
using TaskManagementDemo.Domain.Repositories;

namespace TaskManagementDemo.Application.SubTasks.Commands.AddSubTasksCommand;

public class AddSubTasksCommandHandler(
    ILogger<AddSubTasksCommandHandler> logger,
    ITaskManagementRepository taskManagementRepository,
    IMapper mapper) : IRequestHandler<AddSubTasksCommand>
{
    public async Task Handle(AddSubTasksCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Adding SubTasks [{@SubTasks}] to Task with ID: {ParentTaskId}", request.SubTaskIds, request.ParentTaskId);

        var taskEntity = taskManagementRepository.GetTaskByIdAsync(request.ParentTaskId).Result;

        if (taskEntity == null) 
        {
            throw new NotFoundException(nameof(TaskEntity), request.ParentTaskId.ToString());
        }

        if (request.SubTaskIds.Count == 0)
        {
            throw new BadHttpRequestException("An empty SubTask list is not allowed.");
        }

        foreach (var subTaskId in request.SubTaskIds)
        {
            var subTaskEntity = (await taskManagementRepository.GetTaskByIdAsync(subTaskId));

            if(subTaskEntity == null)
            {
                throw new NotFoundException(nameof(TaskEntity), subTaskId.ToString());
            }

            taskEntity.SubTasks.Add(subTaskEntity);
        }

        await taskManagementRepository.SaveChangesAsync();
    }
}