using MediatR;
using News.Application.Bases.Classes.Command;
using News.Application.Abstraction.Interfaces.Factories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Abstraction.Interfaces.Repositories;
using Category = News.Domain.Entities.NewsCategory;
using News.Application.Bases.Interfaces.Rules;
using News.Application.Features.NewsCategory.Command.UpdateCategory;

namespace News.Application.Features.NewsCategory.Command.CreateCategory
{
    /// <summary>
    /// Handler for creating a news category, responsible for processing the creation request and interacting with the data layer.
    /// </summary>

    public class CreateCategoryCommandHandler : CreateCommandHandler<ICategoryFactory>, IRequestHandler<CreateCategoryCommandRequest, Unit>
    {
        private readonly INewsCategoryRules _rules;

        public static event Action<IList<Category>, string,IUnitOfWork, IWriteRepository<Category>>? OnCategoryCreate;


        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryFactory factory, INewsCategoryRules rules)
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

            OnCategoryCreate?.Invoke(categories,request.Name,unitOfWork,writeRepository);

            await base.AddAsync<Category, ICategoryFactory, CreateCategoryCommandRequest>(unitOfWork, factory, request);
            return default;
        }
    }
}