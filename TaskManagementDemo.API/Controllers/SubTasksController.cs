using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagementDemo.Application.Dtos;
using TaskManagementDemo.Application.SubTasks.Commands.AddSubTasksCommand;
using TaskManagementDemo.Application.SubTasks.Commands.DeleteSubTasksCommand;
using TaskManagementDemo.Application.Tasks.Queries.GetTaskByIdQuery;

namespace TaskManagementDemo.API.Controllers;

[ApiController]
[Route("api/tasks/{parentTaskId:int}/subTasks")]
public class SubTasksController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> AddSubTask([FromRoute] int parentTaskId, [FromBody] AddSubTasksCommand command)
    {
        command.ParentTaskId = parentTaskId;
        await mediator.Send(command);
        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteSubTask([FromRoute] int parentTaskId, [FromBody] DeleteSubTasksCommand command)
    {
        command.ParentTaskId = parentTaskId;
        await mediator.Send(command);
        return NoContent();
    }
}