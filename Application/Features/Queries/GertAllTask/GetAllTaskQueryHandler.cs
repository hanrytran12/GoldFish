using Application.DTOs;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.GertAllTask
{
    public class GetAllTaskQueryHandler : IRequestHandler<GetAllTaskQuery, List<TaskDTO>>
    {
        private readonly IAppDbContext _context;

        public GetAllTaskQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskDTO>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
        {
            return await _context.Tasks.AsNoTracking()
                .Select(t => new TaskDTO
                {
                    Id = t.Id,
                    Content = t.Content,
                    IsCompleted = t.IsCompleted,
                })
                .ToListAsync(cancellationToken);
        }
    }
}
