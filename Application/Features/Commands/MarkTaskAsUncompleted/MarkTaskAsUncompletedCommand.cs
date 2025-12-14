using MediatR;

namespace Application.Features.Commands.MarkTaskAsUncompleted
{
    public class MarkTaskAsUncompletedCommand : IRequest<string>
    {
        public Guid Id { get; set; }
    }
}
