using MediatR;

namespace Application.Features.Queries.GetTaskById
{
    public class GetTaskByIdQuery : IRequest<Domain.Entities.Task>
    {
        public Guid Id { get; set; }
    }
}
