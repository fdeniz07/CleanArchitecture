using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Service;
using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken
{
    public sealed class CreateNewTokenByRefreshTokenCommandHandler : IRequestHandler<CreateNewTokenByRefreshTokenCommand, LoginCommandResponse>
    {
        private readonly IAuthService _authService;

        public CreateNewTokenByRefreshTokenCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginCommandResponse> Handle(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            LoginCommandResponse response =
                await _authService.CreateTokenByRefreshTokenAsync(request, cancellationToken);
            return response;
        }
    }
}
