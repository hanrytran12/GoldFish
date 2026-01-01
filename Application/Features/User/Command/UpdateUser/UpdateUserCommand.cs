using MediatR;
using System.Text.Json.Serialization;

namespace Application.Features.User.Command.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
