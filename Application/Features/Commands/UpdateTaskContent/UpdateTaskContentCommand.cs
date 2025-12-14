using MediatR;
using System.Text.Json.Serialization;

namespace Application.Features.Commands.UpdateTaskContent
{
    public class UpdateTaskContentCommand : IRequest
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
