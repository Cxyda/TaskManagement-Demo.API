using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagementDemo.Application.Dtos;
using TaskManagementDemo.Application.Tasks.Commands.CreateTaskCommand;
using TaskManagementDemo.Application.Tasks.Commands.DeleteTaskCommand;
using TaskManagementDemo.Application.Tasks.Commands.UpdateTaskCommand;
using TaskManagementDemo.Application.Tasks.Queries.GetAllTasksQuery;
using TaskManagementDemo.Application.Tasks.Queries.GetTaskByIdQuery;

namespace TaskManagementDemo.API.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController(IMediator mediator) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskEntityDto>>> GetAll([FromQuery] GetAllTasksQuery query)
    {
        var restaurants = await mediator.Send(query);
        return Ok(restaurants);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TaskEntityDto>> GetById([FromRoute] int id)
    {
        var task = await mediator.Send(new GetTaskByIdQuery(id));
        return Ok(task);
    }

    [HttpPost]
    public async Task<ActionResult<TaskEntityDto>> Create([FromBody] CreateTaskCommand command)
    {
        var taskId = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = taskId }, null);
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateTaskCommand command)
    {
        command.Id = id;
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await mediator.Send(new DeleteTaskCommand(id));
        return NoContent();
    }
}