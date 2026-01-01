using Application.DTOs;
using MediatR;

namespace Application.Features.User.Query.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDTO>
    {
        public Guid Id { get; set; }
    }
}
