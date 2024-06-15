using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagementDemo.Application.Dtos;
using TaskManagementDemo.Application.Tasks.Commands.CreateTaskCommand;
using TaskManagementDemo.Application.Tasks.Queries.GetAllTasksQuery;
using TaskManagementDemo.Application.Tasks.Queries.GetTaskByIdQuery;

namespace TaskManagementDemo.API.Controllers;

[ApiController]
[Route("api/tasks")]
public class TaskManagementController(IMediator mediator) : ControllerBase
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
}