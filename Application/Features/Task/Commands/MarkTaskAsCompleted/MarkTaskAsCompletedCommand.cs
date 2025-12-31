using MediatR;

namespace Application.Features.Task.Commands.MarkTaskAsCompleted
{
    public class MarkTaskAsCompletedCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
