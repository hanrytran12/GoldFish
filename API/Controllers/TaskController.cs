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
        public async Task<List<Domain.Entities.Task>> GetTasks()
        {
            var query = new Application.Features.Queries.GertAllTask.GetAllTaskQuery();
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<Domain.Entities.Task> GetTaskById(Guid id)
        {
            var query = new Application.Features.Queries.GetTaskById.GetTaskByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] Application.Features.Commands.AddTask.AddTaskCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
