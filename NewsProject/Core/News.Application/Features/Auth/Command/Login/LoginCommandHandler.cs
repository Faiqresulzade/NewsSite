using MediatR;
using News.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using News.Application.Features.Auth.Rules;
using News.Application.Bases.Interfaces.Tokens;
using News.Application.Bases.Interfaces.Rules;

namespace News.Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthRules _authRules;
        private readonly ITokenSrvice _tokenService;
        private readonly ITokenManager _tokenManager;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler(UserManager<User> userManager, IAuthRules authRules, ITokenSrvice tokenService, ITokenManager tokenManager, IConfiguration configuration)
         => (_userManager, _authRules, _tokenService, _tokenManager, _configuration) = (userManager, authRules, tokenService, tokenManager, configuration);

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await _userManager.FindByEmailAsync(request.Mail);
            bool isvalidPassword = await _userManager.CheckPasswordAsync(user, request.Password);
            _authRules.EmailorPasswordShouldNotBeInvalid(user, isvalidPassword);

            IList<string> roles = await _userManager.GetRolesAsync(user);
            JwtSecurityToken token = await _tokenService.CreateToken(user, roles);
            string refreshToken = _tokenService.GenerateRefreshToken();

            await _tokenManager.UpdateUserTokenInfo(user, token, refreshToken, _configuration["JWT:RefreshTokenValidityInDays"]);

            return new()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken,
                Expiration = token.ValidTo
            };
        }
    }
}