using Application.DTOs;
using MediatR;

namespace Application.Features.User.Query.GetAllUser
{
    public class GetAllUserQuery : IRequest<List<UserDTO>>
    {
    }
}
