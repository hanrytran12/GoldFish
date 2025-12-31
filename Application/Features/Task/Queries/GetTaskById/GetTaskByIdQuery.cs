using Application.DTOs;
using MediatR;

namespace Application.Features.Task.Queries.GetTaskById
{
    public class GetTaskByIdQuery : IRequest<TaskDTO>
    {
        public Guid Id { get; set; }
    }
}
