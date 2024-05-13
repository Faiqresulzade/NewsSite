using News.Application.Abstraction.Interfaces.Factories;
using News.Application.Features.NewsCategory.Command.CreateCategory;
using News.Domain.Entities;

namespace News.Persistence.Factories
{
    internal class CategoryFactory : ICategoryFactory
    {
        public NewsCategory Create(CreateCategoryCommandRequest request) => new NewsCategory(request.Name);

    }
}
