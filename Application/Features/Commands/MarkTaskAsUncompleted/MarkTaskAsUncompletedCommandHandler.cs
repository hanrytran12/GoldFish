using Application.Common.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Commands.MarkTaskAsUncompleted
{
    public class MarkTaskAsUncompletedCommandHandler : IRequestHandler<MarkTaskAsUncompletedCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public MarkTaskAsUncompletedCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task Handle(MarkTaskAsUncompletedCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetTaskByIdAsync(request.Id);
            if (task is null)
            {
                throw new NotFoundException("Task not found.");
            }
            task.MarkAsUncompleted();
            _taskRepository.UpdateTask(task);
        }
    }
}
