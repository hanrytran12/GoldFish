using FluentValidation;

namespace Application.Features.Commands.UpdateTaskContent
{
    public class UpdateTaskContentCommandValidator : AbstractValidator<UpdateTaskContentCommand>
    {
        public UpdateTaskContentCommandValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Task content must not be empty.")
                .MaximumLength(100).WithMessage("Task content not greater than 100 words.");
        }
    }
}
