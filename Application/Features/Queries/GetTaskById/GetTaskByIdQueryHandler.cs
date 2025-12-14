using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.GetTaskById
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Domain.Entities.Task>
    {
        private readonly IAppDbContext _context;

        public GetTaskByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Task> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.Where(t => t.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            return task;
        }
    }
}
