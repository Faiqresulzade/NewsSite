using MediatR;
using News.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using News.Application.Bases.Classes.Command;
using News.Application.Bases.Interfaces.Factories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Interfaces.Rules;
using News.Application.Abstraction.Interfaces.Repositories;

namespace News.Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : CreateCommandHandler<IUserFactory>, IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly IAuthRules _authRules;
        private readonly UserManager<User> _userManager;

        private const string _userRole = "user";

        public RegisterCommandHandler(IUnitOfWork unitOfWork, IUserFactory factory, IAuthRules authRules, UserManager<User> userManager) : base(unitOfWork, factory)
         => (_authRules, _userManager) = (authRules, userManager);

        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            _authRules.UserSholdNotBeExist(await _userManager.FindByEmailAsync(request.Email));
            return await this.AddAsync<User, IUserFactory, RegisterCommandRequest>(unitOfWork, factory, request);
        }

        protected async override Task<Unit> AddAsync<Tentity, Tfactory, Trequest>
            (IUnitOfWork unitOfWork, Tfactory factory, Trequest request, IWriteRepository<Tentity>? repository = default)
        {
            await factory.Create(request);
            return default;
        }
    }
}