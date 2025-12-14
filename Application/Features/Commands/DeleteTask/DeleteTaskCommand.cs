using MediatR;

namespace Application.Features.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest<string>
    {
        public Guid Id { get; set; }
    }
}
