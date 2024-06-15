using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagementDemo.Application.Tasks.Commands.CreateTaskCommand;
using TaskManagementDemo.Domain.Entities;
using TaskManagementDemo.Domain.Exceptions;
using TaskManagementDemo.Domain.Repositories;

namespace TaskManagementDemo.Application.Tasks.Commands.DeleteTaskCommand
{
    internal class DeleteTaskCommandHandler(
        ILogger<CreateTaskCommandHandler> logger,
        ITaskManagementRepository taskManagementRepository,
        IMapper mapper) : IRequestHandler<DeleteTaskCommand>
    {
        public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting TaskEntity [{@Request}]", request);

            var taskEntity = await taskManagementRepository.GetTaskByIdAsync(request.Id);

            if (taskEntity == null)
            {
                throw new NotFoundException(nameof(TaskEntity), request.Id.ToString());
            }
            await taskManagementRepository.DeleteAsync(taskEntity);
        }
    }
}
