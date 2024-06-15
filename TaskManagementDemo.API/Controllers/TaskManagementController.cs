using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementDemo.Application.Dtos;
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
}