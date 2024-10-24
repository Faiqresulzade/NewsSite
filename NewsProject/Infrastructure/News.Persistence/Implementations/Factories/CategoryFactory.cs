using News.Domain.Entities;
using News.Application.Abstraction.Interfaces.Factories;
using News.Application.Features.NewsCategory.Command.CreateCategory;
using ServicesRegisterPlugin.Atributes;

namespace News.Persistence.Implementations.Factories
{
    [Scoped(nameof(ICategoryFactory))]
    public class CategoryFactory :  ICategoryFactory
    {
        public async Task<NewsCategory> Create(CreateCategoryCommandRequest request) => new NewsCategory(request.Name);

    }
}
