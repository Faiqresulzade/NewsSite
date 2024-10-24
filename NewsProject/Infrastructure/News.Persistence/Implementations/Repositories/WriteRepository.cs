﻿using Microsoft.EntityFrameworkCore;
using News.Application.Abstraction.Interfaces.Repositories;
using News.Domain.Comman;
using ServicesRegisterPlugin.Atributes;

namespace News.Persistence.Implementations.Repositories
{
    [Scoped(nameof(IWriteRepository<T>))]
    public class WriteRepository<T> :  IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private DbContext _dbContext;

        public WriteRepository(DbContext dbContext) => _dbContext = dbContext;
        private DbSet<T> _table => _dbContext.Set<T>();
        public async Task AddRangeAsync(IList<T> entities) => await _table.AddRangeAsync(entities);
        public async Task HardDeleteAsync(T entity) => await Task.Run(() => _table.Remove(entity));
        public async Task HardDeleteRangeAsync(IList<T> entity) => await Task.Run(() => _table.RemoveRange(entity));
        public async Task<int> SaveAsync() => await _dbContext.SaveChangesAsync();

        public async Task<T> UpdateAsync(T entity)
        {
            _table.Update(entity);
            await SaveAsync();

            return entity;
        }

        public async Task AddAsync(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            await _table.AddAsync(entity);
            await SaveAsync();
        }

        public async Task SoftDeleteAsync(T entity)
        {
            await Task.Run(() => _table.Update(entity));
            await SaveAsync();
        }
    }
}