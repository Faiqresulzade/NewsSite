using MediatR;
using News.Domain.Comman;
using News.Application.Bases.Interfaces.Rules;
using News.Application.Abstraction.Interfaces.UnitOfWorks;

namespace News.Application.Bases.Classes.Command
{
    /// <summary>
    /// Base class for command handlers responsible for deleting entities, 
    /// providing access to a unit of work.
    /// </summary>

    internal abstract class DeleteCommandHandler
    {
        public static event Action<EntityBase>? OnEntityDelete;
        private protected readonly IUnitOfWork unitOfWork;

        public DeleteCommandHandler(in IUnitOfWork unitOfWork, IBaseRule<EntityBase> rules)
        => this.unitOfWork = unitOfWork;

        private protected async virtual Task<Unit> Delete<Tentity>(int id) where Tentity : EntityBase, IEntityBase, new()
        {
            Tentity entity = await unitOfWork.GetReadRepository<Tentity>()
              .GetAsync(c => c.Id == id && !c.IsDeleted);

            OnEntityDelete?.Invoke(entity);

            entity.IsDeleted = true;

            await unitOfWork.GetWriteRepository<Tentity>().UpdateAsync(entity);
            return default;
        }
    }
}