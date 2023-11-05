using CleanArchitecture.Infrastructure.Authentication;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.WebApi.OptionsSetup
{
    public sealed class JwtOptioinsSetup : IConfigureOptions<JwtOptions>
    {
        private readonly IConfiguration _configuration;

        public JwtOptioinsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void Configure(JwtOptions options)
        {
            _configuration.GetSection("JwtOptions").Bind(options);
        }
    }
}
