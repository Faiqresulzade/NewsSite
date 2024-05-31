using MediatR;
using News.Application.Bases.Classes.Command;
using News.Application.Bases.Interfaces.Rules;
using News.Application.Abstraction.Interfaces.Factories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Abstraction.Interfaces.Repositories;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Command.CreateCategory
{
    /// <summary>
    /// Handler for creating a news category, responsible for processing the creation request and interacting with the data layer.
    /// </summary>

    public class CreateCategoryCommandHandler : CreateCommandHandler<ICategoryFactory>, IRequestHandler<CreateCategoryCommandRequest, Unit>
    {
        public static event Action<CreateCategoryCommandRequest, IList<Category>, IUnitOfWork, IWriteRepository<Category>>? OnCategoryCreate;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryFactory factory, INewsCategoryRules rules)
        : base(unitOfWork, factory) { }

        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Category> categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync();
            IWriteRepository<Category> writeRepository = unitOfWork.GetWriteRepository<Category>();

            OnCategoryCreate?.Invoke(request, categories, unitOfWork, writeRepository);

            await base.AddAsync<Category, ICategoryFactory, CreateCategoryCommandRequest>(unitOfWork, factory, request);
            return default;
        }
    }
}