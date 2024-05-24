using Microsoft.AspNetCore.Identity;
using News.Application.Bases.Interfaces.Tokens;
using News.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace News.Infrastructure.Tokens
{
    public class TokenManager : ITokenManager
    {
        private readonly UserManager<User> _userManager;

        public TokenManager(UserManager<User> userManager)
          => _userManager = userManager;

        public async Task UpdateUserTokenInfo(User user, JwtSecurityToken token, string refreshToken, string refreshTokenValidityInDays)
        {
            _ = int.TryParse(refreshTokenValidityInDays, out int refreshTokenValidityInDaysInt);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(refreshTokenValidityInDaysInt);

            var updateTasks = new List<Task>
            {
                _userManager.UpdateAsync(user),
                _userManager.UpdateSecurityStampAsync(user),
                _userManager.SetAuthenticationTokenAsync(user, "default", "AccessToken", new JwtSecurityTokenHandler().WriteToken(token))
            };

            await Task.WhenAll(updateTasks);
        }
    }
}
