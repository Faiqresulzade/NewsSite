using News.Application.Bases.Interfaces.DI;
using News.Application.Features.NewsCategory.Command.CreateCategory;
using News.Domain.Entities;

namespace News.Application.Abstraction.Interfaces.Factories
{
    public interface ICategoryFactory : IDependencyInjections,  IFactory<NewsCategory, CreateCategoryCommandRequest>
    {
        public NewsCategory Create(CreateCategoryCommandRequest request);
    }
}
