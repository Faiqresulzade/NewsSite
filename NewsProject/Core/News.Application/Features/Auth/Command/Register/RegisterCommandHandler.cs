using MediatR;
using News.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using News.Application.Features.Auth.Rules;
using News.Application.Bases.Classes.Command;
using News.Application.Bases.Interfaces.Factories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;

namespace News.Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : CreateCommandHandler<IUserFactory>, IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly AuthRules _authRules;
        private readonly UserManager<User> _userManager;

        private const string _userRole = "user";

        public RegisterCommandHandler(IUnitOfWork unitOfWork, IUserFactory factory, AuthRules authRules, UserManager<User> userManager) : base(unitOfWork, factory)
         => (_authRules, _userManager) = (authRules, userManager);

        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
             _authRules.UserSholdNotBeExist(await _userManager.FindByEmailAsync(request.Email));
            return await base.AddAsync<User, IUserFactory, RegisterCommandRequest>(unitOfWork, factory, request);
        }
    }
}