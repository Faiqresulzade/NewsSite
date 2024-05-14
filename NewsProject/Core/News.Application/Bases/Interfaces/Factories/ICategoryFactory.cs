using News.Application.Bases.Interfaces.DI;
using News.Application.Features.NewsCategory.Command.CreateCategory;
using News.Domain.Entities;

namespace News.Application.Abstraction.Interfaces.Factories
{
    /// <summary>
    /// Factory interface for creating instances of NewsCategory entities from CreateCategoryCommandRequest objects.
    /// </summary>
    public interface ICategoryFactory : IDependencyInjections, IFactory<NewsCategory, CreateCategoryCommandRequest>
    {
        /// <summary>
        /// Creates a new instance of NewsCategory based on the provided CreateCategoryCommandRequest.
        /// </summary>
        /// <param name="request">The request object containing data for creating the category.</param>
        /// <returns>A newly created NewsCategory instance.</returns>
        NewsCategory Create(CreateCategoryCommandRequest request);
    }
}
