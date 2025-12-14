using Domain.Interfaces;
using MediatR;

namespace Application.Features.Commands.MarkTaskAsCompleted
{
    public class MarkTaskAsCompletedCommandHandler : IRequestHandler<MarkTaskAsCompletedCommand, string>
    {
        private readonly ITaskRepository _taskRepository;

        public MarkTaskAsCompletedCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<string> Handle(MarkTaskAsCompletedCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetTaskByIdAsync(request.Id);
            task.MarkAsCompleted();
            _taskRepository.UpdateTask(task);
            return "";
        }
    }
}
