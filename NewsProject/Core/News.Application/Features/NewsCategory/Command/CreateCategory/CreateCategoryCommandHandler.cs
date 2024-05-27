using MediatR;
using News.Application.Abstraction.Interfaces.Factories;
using News.Application.Abstraction.Interfaces.Repositories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Classes.Command;
using News.Application.Features.NewsCategory.Rules;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Command.CreateCategory
{
    /// <summary>
    /// Handler for creating a news category, responsible for processing the creation request and interacting with the data layer.
    /// </summary>

    public class CreateCategoryCommandHandler : CreateCommandHandler<ICategoryFactory>, IRequestHandler<CreateCategoryCommandRequest, Unit>
    {
        private readonly NewsCategoryRules _rules;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryFactory factory, NewsCategoryRules rules)
        : base(unitOfWork, factory)
        {
            _rules = rules;
        }

        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Category> categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync();
            IWriteRepository<Category> writeRepository = unitOfWork.GetWriteRepository<Category>();

            await _rules.CategoryNameMustNotBeSame(categories, request.Name);
            if (await _rules.RestoreDeletedCategoryAsync(categories, request.Name, unitOfWork, writeRepository))
                return default;

            await base.AddAsync<Category, ICategoryFactory, CreateCategoryCommandRequest>(unitOfWork, factory, request);
            return default;
        }
    }
}