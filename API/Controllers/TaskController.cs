using Application.DTOs;
using Application.Features.Task.Commands.AddTask;
using Application.Features.Task.Commands.DeleteTask;
using Application.Features.Task.Commands.MarkTaskAsCompleted;
using Application.Features.Task.Commands.MarkTaskAsUncompleted;
using Application.Features.Task.Commands.UpdateTaskContent;
using Application.Features.Task.Queries.GertAllTask;
using Application.Features.Task.Queries.GetTaskById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskDTO>>> GetTasks([FromQuery] DateTime? date)
        {
            var query = new GetAllTaskQuery { Date = date };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDTO>> GetTaskById(Guid id)
        {
            var query = new GetTaskByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] AddTaskCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTaskById), new { id = result }, result);
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> MarkTaskAsCompleted(Guid id)
        {
            var command = new MarkTaskAsCompletedCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}/uncomplete")]
        public async Task<IActionResult> MarkTaskAsUncompleted(Guid id)
        {
            var command = new MarkTaskAsUncompletedCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}/content")]
        public async Task<IActionResult> UpdateTaskContent(Guid id, [FromBody] UpdateTaskContentCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var command = new DeleteTaskCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
