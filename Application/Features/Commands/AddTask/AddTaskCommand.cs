using MediatR;

namespace Application.Features.Commands.AddTask
{
    public class AddTaskCommand : IRequest<string>
    {
        public string Content { get; set; } = string.Empty;
    }
}
