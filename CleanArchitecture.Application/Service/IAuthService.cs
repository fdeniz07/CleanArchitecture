using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;

namespace CleanArchitecture.Application.Service
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterCommand request);
    }
}
