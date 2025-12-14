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
        public async Task<ActionResult<List<Domain.Entities.Task>>> GetTasks()
        {
            var query = new Application.Features.Queries.GertAllTask.GetAllTaskQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Entities.Task>> GetTaskById(Guid id)
        {
            var query = new Application.Features.Queries.GetTaskById.GetTaskByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] Application.Features.Commands.AddTask.AddTaskCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTaskById), new { id = result }, result);
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> MarkTaskAsCompleted(Guid id)
        {
            var command = new Application.Features.Commands.MarkTaskAsCompleted.MarkTaskAsCompletedCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}/uncomplete")]
        public async Task<IActionResult> MarkTaskAsUncompleted(Guid id)
        {
            var command = new Application.Features.Commands.MarkTaskAsUncompleted.MarkTaskAsUncompletedCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var command = new Application.Features.Commands.DeleteTask.DeleteTaskCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
