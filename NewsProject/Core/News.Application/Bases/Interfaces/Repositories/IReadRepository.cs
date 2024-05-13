using Microsoft.EntityFrameworkCore.Query;
using News.Application.Bases.Interfaces.DI;
using News.Domain.Comman;
using System.Linq.Expressions;

namespace News.Application.Abstraction.Interfaces.Repositories
{
    /// <summary>
    /// Represents a generic read-only repository interface for accessing entities of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of entity for which the repository provides read operations.</typeparam>
    public interface IReadRepository<T> : IDependencyInjections where T : class, IEntityBase, new()
    {
        /// <summary>
        /// Retrieves all entities asynchronously.
        /// </summary>
        /// <param name="predicate">Optional predicate to filter entities.</param>
        /// <param name="include">Function to include related entities.</param>
        /// <param name="orderBy">Function to order entities.</param>
        /// <param name="enableTracking">Flag indicating whether change tracking is enabled.</param>
        /// <returns>A task that represents the asynchronous operation, containing a list of entities.</returns>
        public Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
             Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
             Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
             bool enableTracking = false);

        /// <summary>
        /// Retrieves entities by paging asynchronously.
        /// </summary>
        /// <param name="predicate">Optional predicate to filter entities.</param>
        /// <param name="include">Function to include related entities.</param>
        /// <param name="orderBy">Function to order entities.</param>
        /// <param name="enableTracking">Flag indicating whether change tracking is enabled.</param>
        /// <param name="currentPage">The current page number.</param>
        /// <param name="pageSize">The size of each page.</param>
        /// <returns>A task that represents the asynchronous operation, containing a list of entities for the specified page.</returns>
        public Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false, int currentPage = 1, int pageSize = 3);

        /// <summary>
        /// Retrieves a single entity asynchronously based on the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate to filter entities.</param>
        /// <param name="include">Function to include related entities.</param>
        /// <param name="enableTracking">Flag indicating whether change tracking is enabled.</param>
        /// <returns>A task that represents the asynchronous operation, containing the retrieved entity.</returns>
        public Task<T> GetAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = false);

        /// <summary>
        /// Finds entities based on the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate to filter entities.</param>
        /// <param name="enableTracking">Flag indicating whether change tracking is enabled.</param>
        /// <returns>An IQueryable representing the result of the query.</returns>
        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false);

        /// <summary>
        /// Counts the number of entities asynchronously based on the specified predicate.
        /// </summary>
        /// <param name="predicate">Optional predicate to filter entities.</param>
        /// <returns>A task that represents the asynchronous operation, containing the count of entities.</returns>
        public Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    }
}
