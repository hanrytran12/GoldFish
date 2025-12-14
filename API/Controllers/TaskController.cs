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

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] Application.Features.Commands.AddTask.AddTaskCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
