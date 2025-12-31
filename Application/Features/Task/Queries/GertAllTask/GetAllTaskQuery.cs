using Application.DTOs;
using MediatR;

namespace Application.Features.Task.Queries.GertAllTask
{
    public class GetAllTaskQuery : IRequest<List<TaskDTO>>
    {
        public DateTime? Date { get; set; }
    }
}
