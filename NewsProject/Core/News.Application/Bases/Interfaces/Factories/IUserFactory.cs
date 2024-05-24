using Microsoft.AspNetCore.Identity;
using News.Application.Abstraction.Interfaces.Factories;
using News.Application.Bases.Interfaces.DI;
using News.Application.Features.Auth.Command.Register;
using News.Domain.Entities;

namespace News.Application.Bases.Interfaces.Factories
{
    public interface IUserFactory : IDependencyInjections, IFactory<User, RegisterCommandRequest>
    {
        public Task<User> CreateUser(RegisterCommandRequest request, UserManager<User> userManager, RoleManager<Role> roleManager, string userRole);
        public Task CreateRole(User user, UserManager<User> userManager, RoleManager<Role> roleManager, string userRole);
    }
}
