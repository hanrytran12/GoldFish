using Application.Common.Exceptions;
using Application.DTOs;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.Query.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly IAppDbContext _appDbContext;

        public GetUserByIdQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _appDbContext.Users.Where(u => u.Id == request.Id)
                                                    .Select(u => new UserDTO
                                                    {
                                                        Id = u.Id,
                                                        UserName = u.Username,
                                                        Email = u.Email,
                                                        Phone = u.Phone,
                                                    }).FirstOrDefaultAsync();
            if (user is null)
            {
                throw new NotFoundException("User does not found.");
            }

            return user;
        }
    }
}
