using Domain.Interfaces;
using MediatR;

namespace Application.Features.Commands.MarkTaskAsUncompleted
{
    public class MarkTaskAsUncompletedCommandHandler : IRequestHandler<MarkTaskAsUncompletedCommand, string>
    {
        private readonly ITaskRepository _taskRepository;

        public MarkTaskAsUncompletedCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<string> Handle(MarkTaskAsUncompletedCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetTaskByIdAsync(request.Id);
            task.MarkAsUncompleted();
            _taskRepository.UpdateTask(task);
            return "Task marked as uncompleted successfully.";
        }
    }
}
