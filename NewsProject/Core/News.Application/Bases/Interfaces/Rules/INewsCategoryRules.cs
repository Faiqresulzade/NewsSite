using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Abstraction.Interfaces.Repositories;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Bases.Interfaces.Rules
{
    public interface INewsCategoryRules : IBaseRule<Category>
    {
        Task CategoryNameMustNotBeSame(IList<Category> categories, string newsName);
        Task<bool> RestoreDeletedCategoryAsync(IList<Category> categories, string newsName, IUnitOfWork unitOfWork, IWriteRepository<Category> writeRepository);
        Category FindCategory(IList<Category> categories, int requestId);
    }
}
