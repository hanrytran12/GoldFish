using Application.Common.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Commands.UpdateTaskContent
{
    public class UpdateTaskContentCommandHandler : IRequestHandler<UpdateTaskContentCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public UpdateTaskContentCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task Handle(UpdateTaskContentCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetTaskByIdAsync(request.Id);
            if (task is null)
            {
                throw new NotFoundException("Task not found.");
            }

            task.UpdateContent(request.Content);
            await _taskRepository.UpdateTaskAsync(task);
        }
    }
}
