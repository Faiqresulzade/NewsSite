using News.Application.Abstraction.Interfaces.Repositories;
using News.Domain.Comman;

namespace News.Application.Abstraction.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();

        Task<int> SaveAsync();
        int Save();
    }
}
