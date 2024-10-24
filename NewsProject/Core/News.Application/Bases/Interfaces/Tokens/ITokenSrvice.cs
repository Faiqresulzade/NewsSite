using News.Domain.Entities;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace News.Application.Bases.Interfaces.Tokens
{
    /// <summary>
    /// Interface for token-related services.
    /// Inherits from IDependencyInjections to support dependency injection.
    /// </summary>
    public interface ITokenSrvice 
    {
        /// <summary>
        /// Creates a JWT security token for the specified user and their roles.
        /// </summary>
        /// <param name="user">The user entity for whom the token is to be created.</param>
        /// <param name="roles">The list of roles associated with the user.</param>
        /// <returns>A Task that represents the asynchronous operation, containing the generated JWT security token.</returns>
        Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);

        /// <summary>
        /// Generates a new refresh token.
        /// </summary>
        /// <returns>A string representing the generated refresh token.</returns>
        string GenerateRefreshToken();

        /// <summary>
        /// Retrieves the claims principal from an expired token.
        /// </summary>
        /// <param name="token">The expired token from which to retrieve the claims principal.</param>
        /// <returns>The claims principal extracted from the expired token, or null if the token is invalid.</returns>
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}
