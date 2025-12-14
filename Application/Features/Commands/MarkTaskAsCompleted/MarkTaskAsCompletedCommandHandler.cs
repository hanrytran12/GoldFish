using Application.Common.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Commands.MarkTaskAsCompleted
{
    public class MarkTaskAsCompletedCommandHandler : IRequestHandler<MarkTaskAsCompletedCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public MarkTaskAsCompletedCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task Handle(MarkTaskAsCompletedCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetTaskByIdAsync(request.Id);
            if (task is null)
            {
                throw new NotFoundException("Task not found.");
            }
            task.MarkAsCompleted();
            await _taskRepository.UpdateTaskAsync(task);
        }
    }
}
