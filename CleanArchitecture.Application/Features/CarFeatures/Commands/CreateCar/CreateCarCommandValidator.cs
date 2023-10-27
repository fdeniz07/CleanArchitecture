using FluentValidation;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar
{
    public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Arac adi bos olamaz");
            RuleFor(c => c.Name).NotNull().WithMessage("Arac adi bos olamaz");
            RuleFor(c => c.Name).MinimumLength(3).WithMessage("Arac adi en az 3 karakter olmalidir!");

            RuleFor(c => c.Model).NotEmpty().WithMessage("Arac modeli bos olamaz");
            RuleFor(c => c.Model).NotNull().WithMessage("Arac modeli bos olamaz");
            RuleFor(c => c.Model).MinimumLength(2).WithMessage("Arac modeli en az 3 karakter olmalidir!");

            RuleFor(c => c.EnginePower).NotEmpty().WithMessage("Arac motor gücü bos olamaz");
            RuleFor(c => c.EnginePower).NotNull().WithMessage("Arac motor gücü bos olamaz");
            RuleFor(c => c.EnginePower).GreaterThan(0).WithMessage("Arac motor gücü en az 0'dan büyük olmalidir!");
        }
    }
}
