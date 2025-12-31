using MediatR;

namespace Application.Features.Task.Commands.MarkTaskAsUncompleted
{
    public class MarkTaskAsUncompletedCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
