using MediatR;

namespace Application.Features.Commands.MarkTaskAsCompleted
{
    public class MarkTaskAsCompletedCommand : IRequest<string>
    {
        public Guid Id { get; set; }
    }
}
