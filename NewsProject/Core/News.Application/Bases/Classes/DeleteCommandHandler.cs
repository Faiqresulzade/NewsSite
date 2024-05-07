using MediatR;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Domain.Comman;

namespace News.Application.Bases.Classes
{
    internal abstract class DeleteCommandHandler
    {
        private protected readonly IUnitOfWork unitOfWork;

        public DeleteCommandHandler(in IUnitOfWork unitOfWork)
           => this.unitOfWork = unitOfWork;

        private protected async virtual Task SoftDelete<Tentity>(int id) where Tentity : EntityBase, IEntityBase, new()
        {
            Tentity entity = await unitOfWork.GetReadRepository<Tentity>()
              .GetAsync(c => c.Id == id && !c.IsDeleted);

            entity.IsDeleted = true;

            await unitOfWork.GetWriteRepository<Tentity>().UpdateAsync(entity);
            await unitOfWork.SaveAsync();
        }
    }
}
