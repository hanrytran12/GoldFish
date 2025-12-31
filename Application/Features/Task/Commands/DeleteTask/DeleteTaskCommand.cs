using MediatR;

namespace Application.Features.Task.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
