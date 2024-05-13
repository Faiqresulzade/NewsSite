using News.Application.Abstraction.Interfaces.Factories;
using News.Application.Bases.Interfaces.DI;
using News.Application.Features.NewsCategory.Command.CreateCategory;
using News.Domain.Entities;

namespace News.Persistence.Factories
{
    public class CategoryFactory : ICategoryFactory,IScoped
    {
        public NewsCategory Create(CreateCategoryCommandRequest request) => new NewsCategory(request.Name);

    }
}
