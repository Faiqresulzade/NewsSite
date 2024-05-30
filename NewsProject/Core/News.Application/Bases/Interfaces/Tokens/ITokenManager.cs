using News.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using News.Application.Bases.Interfaces.DI;

namespace News.Application.Bases.Interfaces.Tokens
{
    /// <summary>
    /// Interface for managing token-related operations.
    /// Inherits from IDependencyInjections to support dependency injection.
    /// </summary>
    public interface ITokenManager : IDependencyInjections
    {
        /// <summary>
        /// Updates the user's token information.
        /// </summary>
        /// <param name="user">The user entity whose token information needs to be updated.</param>
        /// <param name="token">The JWT security token to be updated.</param>
        /// <param name="refreshToken">The refresh token associated with the user.</param>
        /// <param name="refreshTokenValidityInDays">The validity period of the refresh token in days.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        Task UpdateUserTokenInfo(User user, JwtSecurityToken token, string refreshToken, string refreshTokenValidityInDays);
    }
}
