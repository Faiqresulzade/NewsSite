using News.Application.Abstraction.Interfaces.Repositories;
using News.Application.Bases.Interfaces.DI;
using News.Domain.Comman;

namespace News.Application.Abstraction.Interfaces.UnitOfWorks
{
    /// <summary>
    /// Represents a unit of work interface for coordinating read and write operations within a single transaction.
    /// </summary>
    public interface IUnitOfWork : IDependencyInjections, IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();
        public Task<int> SaveAsync();
        public int Save();
    }
}