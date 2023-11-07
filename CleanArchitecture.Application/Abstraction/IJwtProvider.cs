using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Abstraction
{
    public interface IJwtProvider
    {
        string CreateToken(User user);
    }
}
