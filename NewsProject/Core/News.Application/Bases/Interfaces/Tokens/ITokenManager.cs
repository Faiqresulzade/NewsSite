using News.Application.Bases.Interfaces.DI;
using News.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace News.Application.Bases.Interfaces.Tokens
{
    public interface ITokenManager : IDependencyInjections
    {
        Task UpdateUserTokenInfo(User user, JwtSecurityToken token, string refreshToken, string refreshTokenValidityInDays);
    }
}
