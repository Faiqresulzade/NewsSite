using MediatR;
using News.Application.Abstraction.Interfaces.Repositories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Classes.Command;
using News.Application.Bases.Interfaces.Services;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Command.UpdateCategory
{
    /// <summary>
    /// Handler for updating a news category, responsible for processing the update request and interacting with the data layer.
    /// </summary>
    internal class UpdateCategoryCommandHandler : UpdateCommandHandler<UpdateCategoryCommandRequest, Category>, IRequestHandler<UpdateCategoryCommandRequest, Unit>
    {
        public static event Action<UpdateCategoryCommandRequest, IList<Category>, IUnitOfWork, IWriteRepository<Category>>? OnCategoryUpdate;

        private readonly ICategoryService _categoryService;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryService categoryService)
        : base(unitOfWork)
        {
            _categoryService = categoryService;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Category> categories = await _categoryService.GetAllCategory();
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