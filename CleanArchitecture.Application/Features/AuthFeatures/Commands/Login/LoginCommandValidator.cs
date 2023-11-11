using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login
{
    public sealed class LoginCommandValidator:AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(u => u.UserNameOrEmail).NotEmpty().WithMessage("Username or Email cannot be null!");
            RuleFor(u => u.UserNameOrEmail).NotNull().WithMessage("Username or Email cannot be null!");
            RuleFor(u => u.UserNameOrEmail).MinimumLength(3).WithMessage("Username or Email must be minimum 3 characters");

            RuleFor(u => u.Password).NotEmpty().WithMessage("Password cannot be null!");
            RuleFor(u => u.Password).NotNull().WithMessage("Password cannot be null!");

            //Minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character
            RuleFor(u => u.Password).Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$").WithMessage("Your password must contain at least 8 characters, one uppercase and lowercase letter, number and symbol!");
        }
    }
}
