using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async System.Threading.Tasks.Task<Guid> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existingUserByUsername = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (existingUserByUsername is not null)
            {
                throw new ConflictException("Username already exists.");
            }

            var existingUserByEmail = await _userRepository.GetUserByEmailAsync(request.Email);
            if (existingUserByEmail is not null)
            {
                throw new ConflictException("Email already exists.");
            }

            var existingUserByPhone = await _userRepository.GetUserByPhoneAsync(request.Phone);
            if (existingUserByPhone is not null)
            {
                throw new ConflictException("Phone number already exists.");
            }

            var hashedPassword = _passwordHasher.Hash(request.Password);

            var user = Domain.Entities.User.Create(
                request.Username,
                hashedPassword,
                request.Email,
                request.Phone);
            await _userRepository.AddUserAsync(user);

            return user.Id;
        }
    }
}
