using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register
{
    public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("Mail bilgisi bos olamaz!");
            RuleFor(u => u.Email).NotNull().WithMessage("Mail bilgisi bos olamaz!");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Gecerli bir email adresi giriniz!");

            RuleFor(u => u.UserName).NotEmpty().WithMessage("Kullanici adi bilgisi bos olamaz!");
            RuleFor(u => u.UserName).NotNull().WithMessage("Kullanici adi bilgisi bos olamaz!");
            RuleFor(u => u.UserName).MinimumLength(3).WithMessage("Kullanici adi en az 3 karakterden olusmalidir!");

            RuleFor(u => u.Password).NotEmpty().WithMessage("Sifre bilgisi bos olamaz!");
            RuleFor(u => u.Password).NotNull().WithMessage("Sifre bilgisi bos olamaz!");

            //Minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character
            RuleFor(u => u.Password).Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$").WithMessage("Sifreniz en az 8 karakter, bir tane büyük-kücük harf,sayi ve sembol isareti icermelidir!");
        }
    }
}
