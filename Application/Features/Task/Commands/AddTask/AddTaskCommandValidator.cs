using FluentValidation;

namespace Application.Features.Task.Commands.AddTask
{
    public class AddTaskCommandValidator : AbstractValidator<AddTaskCommand>
    {
        public AddTaskCommandValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Task content must not be empty.")
                .MaximumLength(100).WithMessage("Task content not greater than 100 words.");
        }
    }
}
