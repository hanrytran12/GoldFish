using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.GertAllTask
{
    public class GetAllTaskQueryHandler : IRequestHandler<GetAllTaskQuery, List<Domain.Entities.Task>>
    {
        private readonly IAppDbContext _context;

        public GetAllTaskQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Task>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
        {
            return await _context.Tasks.ToListAsync(cancellationToken);
        }
    }
}
