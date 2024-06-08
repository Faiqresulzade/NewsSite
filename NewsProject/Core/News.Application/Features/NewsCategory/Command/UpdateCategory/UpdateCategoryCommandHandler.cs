using MediatR;
using News.Application.Abstraction.Interfaces.Repositories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Classes.Command;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Command.UpdateCategory
{
    /// <summary>
    /// Handler for updating a news category, responsible for processing the update request and interacting with the data layer.
    /// </summary>
    internal class UpdateCategoryCommandHandler : UpdateCommandHandler<UpdateCategoryCommandRequest, Category>, IRequestHandler<UpdateCategoryCommandRequest, Unit>
    {
        public static event Action<UpdateCategoryCommandRequest, IList<Category>, IUnitOfWork, IWriteRepository<Category>>? OnCategoryUpdate;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
        : base(unitOfWork) { }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Category> categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            IWriteRepository<Category> writeRepository = unitOfWork.GetWriteRepository<Category>();

            OnCategoryUpdate?.Invoke(request, categories, unitOfWork, writeRepository);

            await unitOfWork.GetWriteRepository<Category>().UpdateAsync(UpdateEntityProperties(request));

            return default;
        }

        private protected override Category UpdateEntityProperties(UpdateCategoryCommandRequest request, Category entity = default)
        {
            // Previously, a mapper was used to convert the request to a Category. 
            // Now, we use an implicit conversion.
            Category mapedData = request;
            return mapedData;
        }
    }
}