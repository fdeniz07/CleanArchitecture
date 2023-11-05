using CleanArchitecture.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.WebApi.OptionsSetup
{
    public class JwtBearerOptionsSetup : IPostConfigureOptions<JwtBearerOptions> //Options Design Pattern
    {
        private readonly JwtOptions _jwtOptions;

        public JwtBearerOptionsSetup(IOptions<JwtOptions> jwtOptions) //IOptions ile sarmallanmazsa degerleri yakalayamaz.
        {
            _jwtOptions = jwtOptions.Value;
        }

        public void PostConfigure(string name, JwtBearerOptions options)
        {
            options.TokenValidationParameters = new()
            {
                ValidateAudience = true, //Olusturulacak token degerini, kimlerin/hangi originlerin/sitelerin kullanici belirledigimiz degerdir. -> www.bilmemne.com
                ValidateIssuer = true, //Olusturulacak token degerini, kimin dagittigini ifade edecegimiz alandir. -> www.myapi.com
                ValidateLifetime = true, //Olusturulan token degerinin süresini kontrol edecek olan dogrulamadir.
                ValidateIssuerSigningKey = true, //Üretilecek token degerinin uygulamamiza ait bir deger oldugunu ifade eden security key verisinin dogrulamasidir.

                ValidAudience = _jwtOptions.Audience,
                ValidIssuer = _jwtOptions.Issuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,

                NameClaimType = ClaimTypes.Name //JWT üzerinden Name claim ine karsilik gelen degeri, User.Identity.Name property sinden elde edebiliriz.
            };
        }
    }
}
