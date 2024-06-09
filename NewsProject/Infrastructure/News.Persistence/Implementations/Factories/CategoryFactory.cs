using News.Domain.Entities;
using News.Application.Bases.Interfaces.DI;
using News.Application.Abstraction.Interfaces.Factories;
using News.Application.Features.NewsCategory.Command.CreateCategory;

namespace News.Persistence.Implementations.Factories
{
    public class CategoryFactory : IScoped, ICategoryFactory
    {
        public async Task<NewsCategory> Create(CreateCategoryCommandRequest request) => new NewsCategory(request.Name);

    }
}
