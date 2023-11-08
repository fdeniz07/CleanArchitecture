using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Abstraction
{
    public interface IJwtProvider
    {
        Task<LoginCommandResponse> CreateTokenAsync(User user);
    }
}
