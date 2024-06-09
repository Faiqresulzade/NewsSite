using News.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using News.Application.Bases.Interfaces.DI;
using News.Application.Bases.Interfaces.Tokens;

namespace News.Infrastructure.Tokens
{
    public class TokenManager : IScoped, ITokenManager
    {
        private readonly UserManager<User> _userManager;
        private const string _loginProvider = "default";
        private const string _tokenName = "AccessToken";

        public TokenManager(UserManager<User> userManager)
          => _userManager = userManager;

        public async Task UpdateUserTokenInfo(User user, JwtSecurityToken token, string refreshToken, string refreshTokenValidityInDays)
        {
            _ = int.TryParse(refreshTokenValidityInDays, out int refreshTokenValidityInDaysInt);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(refreshTokenValidityInDaysInt);

            await _userManager.UpdateAsync(user);
            await _userManager.UpdateSecurityStampAsync(user);
            await _userManager.SetAuthenticationTokenAsync(user, _loginProvider, _tokenName, new JwtSecurityTokenHandler().WriteToken(token));

        }
    }
}