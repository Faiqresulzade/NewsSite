using News.Domain.Entities;
using News.Application.Features.NewsCategory.Command.CreateCategory;

namespace News.Application.Abstraction.Interfaces.Factories
{
    /// <summary>
    /// Factory interface for creating instances of NewsCategory entities from CreateCategoryCommandRequest objects.
    /// </summary>
    public interface ICategoryFactory : IFactory<NewsCategory, CreateCategoryCommandRequest>
    {

    }
}
