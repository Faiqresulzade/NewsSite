using Microsoft.AspNetCore.Identity;
using News.Application.Bases.Interfaces.DI;
using News.Application.Bases.Interfaces.Factories;
using News.Application.Features.Auth.Command.Register;
using News.Domain.Entities;

namespace News.Persistence.Factories
{
    public class UserFactory : IScoped, IUserFactory
    {
        public async Task<User> CreateUser(RegisterCommandRequest request, UserManager<User> userManager, RoleManager<Role> roleManager, string userRole)
        {
            User user = request;

            IdentityResult result = await userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
                await CreateRole(user, userManager, roleManager, userRole);

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