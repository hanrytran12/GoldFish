using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IAppDbContext _context;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginCommandHandler(IAppDbContext context, IJwtTokenGenerator jwtTokenGenerator)
        {
            _context = context;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
               .FirstOrDefaultAsync(u => u.Username == request.Username && u.Password == request.Password, cancellationToken);

            if (user is null)
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            return _jwtTokenGenerator.GenerateToken(user);
        }
    }
}
