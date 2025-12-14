using Application.Common.Exceptions;
using Application.DTOs;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.GetTaskById
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskDTO>
    {
        private readonly IAppDbContext _context;

        public GetTaskByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<TaskDTO> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.Where(t => t.Id == request.Id)
                .AsNoTracking()
                .Select(t => new TaskDTO
                {
                    Id = t.Id,
                    Content = t.Content,
                    IsCompleted = t.IsCompleted,
                })
                .FirstOrDefaultAsync(cancellationToken);
            if (task is null)
            {
                throw new NotFoundException("Task not found.");
            }
            return task;
        }
    }
}
