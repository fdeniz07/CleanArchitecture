using AutoMapper;
using CleanArchitecture.Application.Abstraction;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Service;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Service
{
    public sealed class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        private readonly IJwtProvider _jwtProvider;

        public AuthService(UserManager<User> userManager, IMapper mapper, IMailService mailService, IJwtProvider jwtProvider)
        {
            _userManager = userManager;
            _mapper = mapper;
            _mailService = mailService;
            _jwtProvider = jwtProvider;
        }

        public async Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            User user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null) throw new Exception("User not found");

            if (user.RefreshToken != request.RefreshToken) throw new Exception("Refresh Token is not valid");

            if (user.RefreshTokenExpires < DateTime.Now) throw new Exception("RefreshToken has expired");

            LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
            return response;

        }

        public async Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userManager.Users
                .Where(u => u.UserName == request.UserNameOrEmail || u.Email == request.UserNameOrEmail)
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null) throw new Exception("User not found");

            var result = await _userManager.CheckPasswordAsync(user, request.Password);
            if (result)
            {
                LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
                return response;
            }

            throw new Exception("Password is wrong");
        }

        public async Task RegisterAsync(RegisterCommand request)
        {
            User user = _mapper.Map<User>(request);
            IdentityResult result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            //For Email Sending
            List<string> emails = new();
            emails.Add(request.Email);
            string body = "";

            //await _mailService.SendMailAsync(emails,"Mail Onaylandi",body);
        }
    }
}
