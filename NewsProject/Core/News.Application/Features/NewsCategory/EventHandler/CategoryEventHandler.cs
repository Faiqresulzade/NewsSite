using News.Application.Bases.Interfaces.Rules;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Abstraction.Interfaces.Repositories;
using News.Application.Features.NewsCategory.Command.CreateCategory;
using News.Application.Features.NewsCategory.Command.UpdateCategory;
using Category = News.Domain.Entities.NewsCategory;
using News.Application.Features.NewsCategory.Queries.GetCategoryById;
using MediatR;

namespace News.Application.Features.NewsCategory.EventHandler
{
    public class CategoryEventHandler
    {
        private readonly INewsCategoryRules _rules;

        public CategoryEventHandler(INewsCategoryRules rules)
        => _rules = rules;

        public void SubscribeToEvents()
        {
            UpdateCategoryCommandHandler.OnCategoryUpdate += HandleCategoryUpdate;
            CreateCategoryCommandHandler.OnCategoryCreate += HandleCategoryCreate;
            GetCategoryQueryHandler.OnCategoryGet += HandleCategoryGet;
        }

        private Category HandleCategoryGet(IList<Category> categories, int id)
        {
            return _rules.FindCategory(categories, id);
        }

        private void HandleCategoryUpdate(UpdateCategoryCommandRequest request, IList<Category> categories, IUnitOfWork unitOfWork, IWriteRepository<Category> writeRepository)
        {
            _rules.FindCategory(categories, request.Id);
            _rules.CategoryNameMustNotBeSame(categories, request.Name).Wait();
            if (_rules.RestoreDeletedCategoryAsync(categories, request.Name, unitOfWork, writeRepository).Result)
                return;
        }

        private void HandleCategoryCreate(CreateCategoryCommandRequest request, IList<Category> categories, IUnitOfWork unitOfWork, IWriteRepository<Category> writeRepository)
        {
            _rules.CategoryNameMustNotBeSame(categories, request.Name).Wait();
            if (_rules.RestoreDeletedCategoryAsync(categories, request.Name, unitOfWork, writeRepository).Result)
                return;
        }

        public void UnsubscribeFromEvents()
        {
            UpdateCategoryCommandHandler.OnCategoryUpdate -= HandleCategoryUpdate;
            CreateCategoryCommandHandler.OnCategoryCreate -= HandleCategoryCreate;
            GetCategoryQueryHandler.OnCategoryGet -= HandleCategoryGet;
        }

        ~CategoryEventHandler()
        => UnsubscribeFromEvents();

    }
}