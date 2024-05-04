using MediatR;
using News.Application.Abstraction.Interfaces.Factories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Domain.Comman;

namespace News.Application.Extensions.UnitOfWorks
{
    public static class UnitOfWorkExtension
    {
        public static async Task AddAsync<Tentity, Tfactory, Trequest>(this IUnitOfWork unitOfWork, Tfactory factory, Trequest request)
            where Tentity : class, IEntityBase, new()
            where Tfactory : IFactory<Tentity, Trequest>
            where Trequest : IRequest
        {
            Tentity entity = factory.Create(request);
            var categoryRepository = unitOfWork.GetWriteRepository<Tentity>();
            await categoryRepository.AddAsync(entity);
        }
    }
}
