using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagementDemo.Domain.Entities;
using TaskManagementDemo.Domain.Exceptions;
using TaskManagementDemo.Domain.Repositories;

namespace TaskManagementDemo.Application.Tasks.Commands.UpdateTaskCommand;

public class UpdateTaskCommandHandler(
    ILogger<UpdateTaskCommandHandler> logger,
    ITaskManagementRepository taskManagementRepository,
    IMapper mapper) : IRequestHandler<UpdateTaskCommand>
{
    public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating TaskEntity [{@Request}]", request);

        var taskEntity = await taskManagementRepository.GetTaskByIdAsync(request.Id);

        if (taskEntity == null)
        {
            throw new NotFoundException(nameof(TaskEntity), request.Id.ToString());
        }

        mapper.Map(request, taskEntity);
        await taskManagementRepository.SaveChangesAsync();
    }
}