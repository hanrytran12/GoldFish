using MediatR;

namespace Application.Features.Commands.MarkTaskAsUncompleted
{
    public class MarkTaskAsUncompletedCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
