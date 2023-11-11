using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register
{
    public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email cannot be null!");
            RuleFor(u => u.Email).NotNull().WithMessage("Email cannot be null!");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Please enter a valid email address!");

            RuleFor(u => u.UserName).NotEmpty().WithMessage("Username cannot be null!");
            RuleFor(u => u.UserName).NotNull().WithMessage("Username cannot be null!");
            RuleFor(u => u.UserName).MinimumLength(3).WithMessage("Username must be minimum 3 characters");

            RuleFor(u => u.Password).NotEmpty().WithMessage("Password cannot be null!");
            RuleFor(u => u.Password).NotNull().WithMessage("Password cannot be null!");

            //Minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character
            RuleFor(u => u.Password).Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$").WithMessage("Your password must contain at least 8 characters, one uppercase and lowercase letter, number and symbol!");
        }
    }
}
