using MediatR;
using News.Application.Abstraction.Interfaces.Factories;
using News.Application.Abstraction.Interfaces.Repositories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Domain.Comman;

namespace News.Application.Extensions.UnitOfWorks
{
    /// <summary>
    /// Extension methods for working with unit of work patterns.
    /// </summary>
    public static class UnitOfWorkExtension
    {
        /// <summary>
        /// Asynchronously adds a new entity to the repository using the specified factory and request.
        /// </summary>
        /// <typeparam name="Tentity">The type of entity to add.</typeparam>
        /// <typeparam name="Tfactory">The type of factory used to create the entity.</typeparam>
        /// <typeparam name="Trequest">The type of request used to create the entity.</typeparam>
        /// <param name="unitOfWork">The unit of work instance.</param>
        /// <param name="factory">The factory instance used to create the entity.</param>
        /// <param name="request">The request instance used to create the entity.</param>
        public static async Task AddAsync<Tentity, Tfactory, Trequest>(this IUnitOfWork unitOfWork, Tfactory factory, Trequest request)
            where Tentity : class, IEntityBase, new()
            where Tfactory : IFactory<Tentity, Trequest>
            where Trequest : IRequest
        {
            Tentity entity = factory.Create(request);
            IWriteRepository<Tentity> repository = unitOfWork.GetWriteRepository<Tentity>();
            await repository.AddAsync(entity);
        }
    }
}
