using News.Application.Abstraction.Interfaces.Factories;
using News.Application.Bases.Interfaces.DI;
using News.Application.Features.NewsCategory.Command.CreateCategory;
using News.Domain.Entities;

namespace News.Persistence.Factories
{
    public class CategoryFactory : IScoped, ICategoryFactory
    {
        public NewsCategory Create(CreateCategoryCommandRequest request) => new NewsCategory(request.Name);

    }
}
