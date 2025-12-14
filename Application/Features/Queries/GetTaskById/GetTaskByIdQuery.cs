using Application.DTOs;
using MediatR;

namespace Application.Features.Queries.GetTaskById
{
    public class GetTaskByIdQuery : IRequest<TaskDTO>
    {
        public Guid Id { get; set; }
    }
}
