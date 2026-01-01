using Application.DTOs;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.Query.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<UserDTO>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetAllUserQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<UserDTO>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return await _appDbContext.Users.Select(u => new UserDTO
            {
                Id = u.Id,
                UserName = u.Username,
                Email = u.Email,
                Phone = u.Phone,
            }).ToListAsync();
        }
    }
}
