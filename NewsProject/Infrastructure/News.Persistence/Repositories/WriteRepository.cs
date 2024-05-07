using Microsoft.EntityFrameworkCore;
using News.Application.Abstraction.Interfaces.Repositories;
using News.Domain.Comman;

namespace News.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        public WriteRepository(in DbContext dbContext) => _dbContext = dbContext;
        private readonly DbContext _dbContext;

        private DbSet<T> _table => _dbContext.Set<T>();

        public async Task AddAsync(T entity) => await _table.AddAsync(entity);

        public async Task AddRangeAsync(IList<T> entities) => await _table.AddRangeAsync(entities);

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => _table.Update(entity));
            return entity;
        }
        public async Task HardDeleteAsync(T entity) => await Task.Run(() => _table.Remove(entity));

        public async Task HardDeleteRangeAsync(IList<T> entity) => await Task.Run(() => _table.RemoveRange(entity));

        public async Task SoftDeleteAsync(T entity) => await Task.Run(() => _table.Update(entity));

    }
}
