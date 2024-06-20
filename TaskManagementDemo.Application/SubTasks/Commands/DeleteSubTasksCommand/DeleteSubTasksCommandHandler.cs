using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TaskManagementDemo.Domain.Exceptions;
using TaskManagementDemo.Domain.Repositories;
using TaskManagementDemo.Domain.Entities;


namespace TaskManagementDemo.Application.SubTasks.Commands.DeleteSubTasksCommand;

public class DeleteSubTasksCommandHandler(
    ILogger<DeleteSubTasksCommandHandler> logger,
    ITaskManagementRepository taskManagementRepository,
    IMapper mapper) : IRequestHandler<DeleteSubTasksCommand>
{
    public async Task Handle(DeleteSubTasksCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting SubTasks [{@SubTaskIds}] from Task with ID: {ParentTaskId}", request.SubTaskIds, request.ParentTaskId);

        var taskEntity = taskManagementRepository.GetTaskByIdAsync(request.ParentTaskId).Result;

        if(taskEntity == null)
        {
            throw new NotFoundException(nameof(TaskEntity), request.ParentTaskId.ToString());
        }

        if (request.SubTaskIds.Count == 0)
        {
            throw new BadHttpRequestException("An empty SubTaskId list is not allowed.");
        }

        foreach (var subTaskId in request.SubTaskIds)
        {
            var subTask = taskEntity.SubTasks.FirstOrDefault(x => x.Id == subTaskId);
            if (subTask == null)
            {
                continue;
            }
            taskEntity.SubTasks.Remove(subTask);
        }

        await taskManagementRepository.SaveChangesAsync();
    }
}