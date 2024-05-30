using MediatR;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Interfaces.Rules;
using News.Domain.Comman;

namespace News.Application.Bases.Classes.Command
{
    /// <summary>
    /// Base class for command handlers responsible for deleting entities, 
    /// providing access to a unit of work.
    /// </summary>

    internal abstract class DeleteCommandHandler
    {
        private protected readonly IUnitOfWork unitOfWork;
        private protected readonly IBaseRule<EntityBase> rules;

        public DeleteCommandHandler(in IUnitOfWork unitOfWork, IBaseRule<EntityBase> rules)
            => (this.unitOfWork, this.rules) = (unitOfWork, rules);

        private protected async virtual Task<Unit> Delete<Tentity>(int id) where Tentity : EntityBase, IEntityBase, new()
        {
            Tentity entity = await unitOfWork.GetReadRepository<Tentity>()
              .GetAsync(c => c.Id == id && !c.IsDeleted);

            rules.EntityNotFound(entity);
            entity.IsDeleted = true;

            await unitOfWork.GetWriteRepository<Tentity>().UpdateAsync(entity);
            return Unit.Value;
        }
    }
}