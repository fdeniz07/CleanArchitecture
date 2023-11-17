using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken
{
    public sealed class CreateNewTokenByRefreshTokenCommandValidator:AbstractValidator<CreateNewTokenByRefreshTokenCommand>
    {
        public CreateNewTokenByRefreshTokenCommandValidator()
        {
            RuleFor(u => u.UserId).NotEmpty().WithMessage("User cannot be null!");
            RuleFor(u => u.UserId).NotNull().WithMessage("User cannot be null!");

            RuleFor(u => u.RefreshToken).NotNull().WithMessage("Refresh Token cannot be null!");
            RuleFor(u => u.RefreshToken).NotEmpty().WithMessage("Refresh Token cannot be null!");
        }
    }
}
