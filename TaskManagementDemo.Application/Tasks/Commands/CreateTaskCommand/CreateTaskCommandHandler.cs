using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagementDemo.Domain.Entities;
using TaskManagementDemo.Domain.Repositories;

namespace TaskManagementDemo.Application.Tasks.Commands.CreateTaskCommand
{
    internal class CreateTaskCommandHandler(
        ILogger<CreateTaskCommandHandler> logger,
        ITaskManagementRepository taskManagementRepository,
        IMapper mapper) : IRequestHandler<CreateTaskCommand, int>
    {
        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating TaskEntity [{@Request}]", request);

            var taskEntity = mapper.Map<TaskEntity>(request);

            int taskId = await taskManagementRepository.CreateAsync(taskEntity);

            return taskId;
        }
    }
}
