using MediatR;
using News.Application.Bases.Classes.Command;
using News.Application.Abstraction.Interfaces.Factories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Abstraction.Interfaces.Repositories;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Command.CreateCategory
{
    /// <summary>
    /// Handler for creating a news category, responsible for processing the creation request and interacting with the data layer.
    /// </summary>
    internal class CreateCategoryCommandHandler : CreateCommandHandler<Category, ICategoryFactory, CreateCategoryCommandRequest>, IRequestHandler<CreateCategoryCommandRequest, Unit>
    {
        public static event Action<CreateCategoryCommandRequest, IList<Category>, IUnitOfWork, IWriteRepository<Category>>? OnCategoryCreate;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryFactory factory)
        : base(unitOfWork, factory) { }

        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Category> categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync(x => x.IsDeleted || !x.IsDeleted);
            IWriteRepository<Category> writeRepository = unitOfWork.GetWriteRepository<Category>();

            OnCategoryCreate?.Invoke(request, categories, unitOfWork, writeRepository);

            await base.AddAsync(unitOfWork, factory, request);
            return default;
        }
    }
}