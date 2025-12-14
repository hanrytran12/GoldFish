using Application.Common.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetTaskByIdAsync(request.Id);
            if (task is null)
            {
                throw new NotFoundException("Task not found.");
            }
            await _taskRepository.DeleteTaskAsync(task);
        }
    }
}
