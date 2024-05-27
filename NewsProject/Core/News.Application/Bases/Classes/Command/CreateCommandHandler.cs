using MediatR;
using News.Application.Abstraction.Interfaces.Factories;
using News.Application.Abstraction.Interfaces.Repositories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Domain.Comman;

namespace News.Application.Bases.Classes.Command
{
    /// <summary>
    /// Base class for command handlers responsible for creating entities,
    /// providing access to a unit of work and a factory for entity creation.
    /// </summary>

    public abstract class CreateCommandHandler<Tfactory>
    {
        private protected readonly IUnitOfWork unitOfWork;
        private protected readonly Tfactory factory;

        public CreateCommandHandler(in IUnitOfWork unitOfWork, Tfactory factory)
        {
            this.unitOfWork = unitOfWork;
            this.factory = factory;
        }

        protected virtual async Task<Unit> AddAsync<Tentity, Tfactory, Trequest>(IUnitOfWork unitOfWork, Tfactory factory, Trequest request, IWriteRepository<Tentity> repository = default)
          where Tentity : class, IEntityBase, new()
          where Tfactory : IFactory<Tentity, Trequest>
          where Trequest : IRequest<Unit>
        {
            Tentity entity = await factory.Create(request);
            repository ??= unitOfWork.GetWriteRepository<Tentity>();

            await repository.AddAsync(entity);
            await repository.SaveAsync();

            return Unit.Value;
        }
    }
}