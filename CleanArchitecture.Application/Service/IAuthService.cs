using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;

namespace CleanArchitecture.Application.Service
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterCommand request);
        Task<LoginCommandResponse> LoginAsync(LoginCommand request,CancellationToken cancellationToken);
    }
}
