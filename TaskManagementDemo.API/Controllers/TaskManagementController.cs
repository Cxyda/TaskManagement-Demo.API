using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementDemo.Application.Dtos;
using TaskManagementDemo.Application.Tasks.GetAllTasksQuery;

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
}