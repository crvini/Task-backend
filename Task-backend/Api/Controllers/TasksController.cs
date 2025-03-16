using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task_backend.Core.Commands;
using Task_backend.Core.Dtos;
using Task_backend.Core.Queries;

namespace Task_backend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : Controller
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<Task_backend.Core.Entities.Task>>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetTasksQuery();
        var result = await _mediator.Send(query);
        var response = new ApiResponse<IEnumerable<Task_backend.Core.Entities.Task>>(result);
        return Ok(response);
    }
    
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<CreateDto>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateOrUpdate([FromBody] TaskCreateCommand command)
    {
        
        var result = await _mediator.Send(command);
        var response = new ApiResponse<CreateDto>(new CreateDto { Id = result } );
        return Ok(response);
    }
    
    [HttpPatch("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<bool>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Delete([FromRoute] string id,[FromBody] TaskUpdateCommand command)
    {
        command = new TaskUpdateCommand()
        {
            IsCompleted = command.IsCompleted,
            Id = id,
        };
        var result = await _mediator.Send(command);
        var response = new ApiResponse<bool>(result);
        return Ok(response);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<bool>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Delete(string id)
    {
        TaskDeleteCommand command = new TaskDeleteCommand()
        {
            Id = id
        };
        var result = await _mediator.Send(command);
        var response = new ApiResponse<bool>(result);
        return Ok(response);
    }
}