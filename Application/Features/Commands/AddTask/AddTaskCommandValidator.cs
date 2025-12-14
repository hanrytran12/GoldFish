using FluentValidation;

namespace Application.Features.Commands.AddTask
{
    public class AddTaskCommandValidator : AbstractValidator<AddTaskCommand>
    {
        public AddTaskCommandValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Task content must not be empty.");
        }
    }
}
