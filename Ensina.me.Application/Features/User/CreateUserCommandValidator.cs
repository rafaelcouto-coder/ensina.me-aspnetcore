using FluentValidation;

namespace Ensina.me.Application.Features.User
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Username)
                .NotEmpty().WithMessage("{PropertyUsername} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyUsername} must not exceed 50 characters.");

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyFirstName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyFirstName} must not exceed 50 characters.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyLastName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyLastName} must not exceed 50 characters.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyEmail} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyEmail} must not exceed 50 characters.")
                .EmailAddress();

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyPassword} is required")
                .MaximumLength(50).WithMessage("{PropertyPassword} must not exceed 50 characters.")
                .NotNull();
        }
    }
}

