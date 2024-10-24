using News.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using News.Application.Features.Auth.Command.Register;
using News.Application.Abstraction.Interfaces.Factories;

namespace News.Application.Bases.Interfaces.Factories
{
    /// <summary>
    /// Factory interface for creating and managing user-related operations.
    /// Inherits from IDependencyInjections and IFactory to support dependency injection and
    /// user creation based on RegisterCommandRequest.
    /// </summary>  
    public interface IUserFactory : IFactory<User, RegisterCommandRequest>
    {
        /// <summary>
        /// Creates and assigns a role to a user.
        /// </summary>
        /// <param name="user">The user entity to which the role will be assigned.</param>
        /// <param name="userManager">The UserManager instance for managing user operations.</param>
        /// <param name="roleManager">The RoleManager instance for managing role operations.</param>
        /// <param name="userRole">The role to be assigned to the user.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>    
        public Task CreateRole(User user, UserManager<User> userManager, RoleManager<Role> roleManager, string userRole);
    }
}
