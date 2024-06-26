﻿using News.Application.Abstraction.Interfaces.Repositories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Interfaces.DI;
using News.Persistence.Context;
using News.Persistence.Implementations.Repositories;

namespace News.Persistence.Implementations.UnitOfWorks
{
    public class UnitOfWork : IScoped, IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext) => _dbContext = dbContext;
        public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();
        public int Save() => _dbContext.SaveChanges();
        public async Task<int> SaveAsync() => await _dbContext.SaveChangesAsync();
        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_dbContext);
        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_dbContext);
    }
}