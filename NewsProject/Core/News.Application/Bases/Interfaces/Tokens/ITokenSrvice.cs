using News.Application.Bases.Interfaces.DI;
using News.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace News.Application.Bases.Interfaces.Tokens
{
    public interface ITokenSrvice : IDependencyInjections
    {
        Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}
