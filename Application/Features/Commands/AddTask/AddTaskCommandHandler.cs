using Domain.Interfaces;
using MediatR;

namespace Application.Features.Commands.AddTask
{
    public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, string>
    {
        private readonly ITaskRepository _taskRepository;

        public AddTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task<string> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            var task = Domain.Entities.Task.Create(request.Content);
            _taskRepository.AddTask(task);
            return Task.FromResult(task.Id.ToString());
        }
    }
}
