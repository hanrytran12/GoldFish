using Application.Common.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.User.Command.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async System.Threading.Tasks.Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id);
            if (user is null)
            {
                throw new NotFoundException("User not found.");
            }
            await _userRepository.DeleteUserAsync(user);
        }
    }
}
