using MediatR;
using Microsoft.AspNetCore.Identity;
using News.Application.Bases.Interfaces.Factories;
using News.Application.Features.Auth.Rules;
using News.Domain.Entities;

namespace News.Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly AuthRules _authRules;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUserFactory _userFactory;

        private const string _userRole = "user";

        public RegisterCommandHandler(AuthRules authRules, UserManager<User> userManager, RoleManager<Role> roleManager, IUserFactory userFactory)
         => (_authRules, _userManager, _roleManager, _userFactory) = (authRules, userManager, roleManager, userFactory);

        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await _authRules.UserSholdNotBeExist(await _userManager.FindByEmailAsync(request.Email));
            await _userFactory.CreateUser(request, _userManager, _roleManager, _userRole);

            return Unit.Value;
        }
    }
}