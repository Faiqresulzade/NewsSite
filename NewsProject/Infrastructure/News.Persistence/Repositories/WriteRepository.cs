using Microsoft.EntityFrameworkCore;
using News.Application.Abstraction.Interfaces.Repositories;
using News.Domain.Comman;

namespace News.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext _dbContext;

        public WriteRepository(DbContext dbContext) => _dbContext = dbContext;

        private DbSet<T> Table => _dbContext.Set<T>();

        public async Task AddAsync(T entity) => await Table.AddAsync(entity);

        public async Task AddRangeAsync(IList<T> entities) => await Table.AddRangeAsync(entities);

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }
        public async Task HardDeleteAsync(T entity) => await Task.Run(() => Table.Remove(entity));

        public async Task HardDeleteRangeAsync(IList<T> entity) => await Task.Run(() => Table.RemoveRange(entity));

        public async Task SoftDeleteAsync(T entity) => await Task.Run(() => Table.Update(entity));

    }
}
