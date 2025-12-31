using MediatR;

namespace Application.Features.Auth.Command
{
    public class LoginCommand : IRequest<string>
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
