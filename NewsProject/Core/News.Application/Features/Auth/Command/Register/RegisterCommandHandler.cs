using MediatR;
using News.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using News.Application.Bases.Classes.Command;
using News.Application.Bases.Interfaces.Factories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Abstraction.Interfaces.Repositories;

namespace News.Application.Features.Auth.Command.Register
{
    internal class RegisterCommandHandler : CreateCommandHandler<IUserFactory>, IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly UserManager<User> _userManager;

        private const string _userRole = "user";

        public static event Action<User>? OnUserRegister;

        public RegisterCommandHandler(IUnitOfWork unitOfWork, IUserFactory factory, UserManager<User> userManager) : base(unitOfWork, factory)
         => _userManager = userManager;

        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            OnUserRegister?.Invoke(await _userManager.FindByEmailAsync(request.Email));
            await this.AddAsync<User, IUserFactory, RegisterCommandRequest>(unitOfWork, factory, request);
            return default;
        }

        protected async override Task<Tentity> AddAsync<Tentity, Tfactory, Trequest>
        (IUnitOfWork unitOfWork, Tfactory factory, Trequest request, IWriteRepository<Tentity>? repository = default)
          => await factory.Create(request);
    }
}