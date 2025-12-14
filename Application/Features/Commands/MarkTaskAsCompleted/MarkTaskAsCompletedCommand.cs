using MediatR;

namespace Application.Features.Commands.MarkTaskAsCompleted
{
    public class MarkTaskAsCompletedCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
