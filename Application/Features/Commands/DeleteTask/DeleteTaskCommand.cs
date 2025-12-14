using MediatR;

namespace Application.Features.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
