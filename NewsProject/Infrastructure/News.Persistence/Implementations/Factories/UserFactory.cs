using Microsoft.AspNetCore.Identity;
using News.Application.Bases.Interfaces.Factories;
using News.Application.Features.Auth.Command.Register;
using News.Domain.Entities;
using ServicesRegisterPlugin.Atributes;

namespace News.Persistence.Implementations.Factories
{
    [Scoped(nameof(IUserFactory))]
    public class UserFactory : IUserFactory
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UserFactory(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<User> Create(RegisterCommandRequest request)
        {
            User user = request;

            IdentityResult result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
                await CreateRole(user, _userManager, _roleManager, "user");

            return user;
        }

        public async Task CreateRole(User user, UserManager<User> userManager, RoleManager<Role> roleManager, string userRole)
        {
            if (!await roleManager.RoleExistsAsync(userRole))
                await roleManager.CreateAsync(new Role
                {
                    Name = userRole,
                    NormalizedName = userRole.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                });

            await userManager.AddToRoleAsync(user, userRole);
        }
    }
}