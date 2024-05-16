using News.Application.Abstraction.Interfaces.Repositories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Classes.Rules;
using News.Application.Bases.Interfaces.DI;
using News.Application.Features.NewsCategory.Exceptions;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Rules
{
    public class NewsCategoryRules : BaseRules, ITransient
    {
        public Task CategoryNameMustNotBeSame(IList<Category> categories, string newsName)
        {
            if (categories.Any(c => c.Name == newsName && !c.IsDeleted)) throw new CategoryNameMustNotBeSameException();
            return Task.CompletedTask;
        }

        public async Task<bool> RestoreDeletedCategoryAsync(IList<Category> categories, string newsName, IUnitOfWork unitOfWork, IWriteRepository<Category> writeRepository)
        {
            var category = categories.FirstOrDefault(c => c.Name == newsName && c.IsDeleted);
            if (category is not null)
            {
                category.IsDeleted = false;
                await writeRepository.UpdateAsync(category);
                await unitOfWork.SaveAsync();
                return true;
            }

            return false;
        }

        public Category FindCategory(IList<Category> categories, int requestId)
        {
            Category? category = categories.FirstOrDefault(c => c.Id == requestId && !c.IsDeleted);

            if (category is not null)
                return category;

            throw new CategoryNotFoundException();
        }
    }
}