using FluentValidation;

namespace Application.Features.User.Command.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.UserName)
                 .NotEmpty().WithMessage("Username is required.")
                 .MinimumLength(3).WithMessage("Username must be at least 3 characters long.")
                 .MaximumLength(20).WithMessage("Username must not exceed 20 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email is required.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?[0-9]\d{1,14}$").WithMessage("A valid phone number is required.");
        }
    }
}
