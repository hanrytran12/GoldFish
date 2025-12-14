using Application.DTOs;
using MediatR;

namespace Application.Features.Queries.GertAllTask
{
    public class GetAllTaskQuery : IRequest<List<TaskDTO>>
    {
    }
}
