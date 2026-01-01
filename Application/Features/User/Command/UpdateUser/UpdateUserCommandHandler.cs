using Application.Common.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.User.Command.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async System.Threading.Tasks.Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id);
            if (user is null)
            {
                throw new NotFoundException("User not found.");
            }

            var isUsernameExist = await _userRepository.GetUserByUsernameAsync(request.UserName);
            if (isUsernameExist is not null && isUsernameExist.Id != request.Id)
            {
                throw new ConflictException("Username already exists.");
            }

            var isEmailExist = await _userRepository.GetUserByEmailAsync(request.Email);
            if (isEmailExist is not null && isEmailExist.Id != request.Id)
            {
                throw new ConflictException("Email already exists.");
            }

            var isPhoneExist = await _userRepository.GetUserByPhoneAsync(request.Phone);
            if (isPhoneExist is not null && isPhoneExist.Id != request.Id)
            {
                throw new ConflictException("Phone number already exists.");
            }

            user.UpdateUsername(request.UserName);
            user.UpdateEmail(request.Email);
            user.UpdatePhone(request.Phone);
            await _userRepository.UpdateUserAsync(user);
        }
    }
}
