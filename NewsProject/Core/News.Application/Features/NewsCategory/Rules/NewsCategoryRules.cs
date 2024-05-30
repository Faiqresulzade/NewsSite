using News.Application.Abstraction.Interfaces.Repositories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Interfaces.DI;
using News.Application.Bases.Interfaces.Rules;
using News.Application.Features.NewsCategory.Command.UpdateCategory;
using News.Application.Features.NewsCategory.Exceptions;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Rules
{
    /// <summary>
    /// Provides business rules related to news categories.
    /// </summary>
    public class NewsCategoryRules : ITransient, INewsCategoryRules
    {
        public void SubscribeEventMethod()
        {
            UpdateCategoryCommandHandler.OnCategoryUpdate += InvokeEventMethod;
        }

        private void InvokeEventMethod(UpdateCategoryCommandRequest request, IList<Category> categories, IUnitOfWork unitOfWork, IWriteRepository<Category> writeRepository)
        {
            FindCategory(categories, request.Id);
            CategoryNameMustNotBeSame(categories, request.Name).Wait();
            if (RestoreDeletedCategoryAsync(categories, request.Name, unitOfWork, writeRepository).Result)
                return;
        }

        /// <summary>
        /// Ensures that the category name is not the same as an existing category name.
        /// </summary>
        /// <param name="categories">The list of existing categories.</param>
        /// <param name="newsName">The name of the category to check.</param>
        /// <exception cref="CategoryNameMustNotBeSameException">Thrown when a category with the same name already exists.</exception>
        public Task CategoryNameMustNotBeSame(IList<Category> categories, string newsName)
        {
            if (categories.Any(c => c.Name == newsName && !c.IsDeleted)) throw new CategoryNameMustNotBeSameException();
            return Task.CompletedTask;
        }

        /// <summary>
        /// Restores a deleted category if it exists in the list.
        /// </summary>
        /// <param name="categories">The list of existing categories.</param>
        /// <param name="newsName">The name of the category to restore.</param>
        /// <param name="unitOfWork">The unit of work for handling database operations.</param>
        /// <param name="writeRepository">The repository for writing category data.</param>
        /// <returns>A task representing the asynchronous operation. The task result is true if the category was restored, false otherwise.</returns>
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

        /// <summary>
        /// Finds a category by its ID.
        /// </summary>
        /// <param name="categories">The list of existing categories.</param>
        /// <param name="requestId">The ID of the category to find.</param>
        /// <returns>The found category.</returns>
        /// <exception cref="CategoryNotFoundException">Thrown when the category is not found.</exception>
        public Category FindCategory(IList<Category> categories, int requestId)
        {
            Category? category = categories.FirstOrDefault(c => c.Id == requestId && !c.IsDeleted);

            return EntityNotFound(category);
        }

        public Category EntityNotFound(Category? category)
        {
            if (category is not null)
                return category;

            throw new CategoryNotFoundException();
        }

        private void UnsubscribeEventMethod()
        {
            UpdateCategoryCommandHandler.OnCategoryUpdate -= InvokeEventMethod;
        }

        ~NewsCategoryRules()
        => UnsubscribeEventMethod();

    }
}