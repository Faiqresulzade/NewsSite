using MediatR;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Classes.Command;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Command.UpdateCategory
{
    /// <summary>
    /// Handler for updating a news category, responsible for processing the update request and interacting with the data layer.
    /// </summary>

    internal class UpdateCategoryCommandHandler : UpdateCommandHandler, IRequestHandler<UpdateCategoryCommandRequest>
    {
        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
        : base(unitOfWork) { }

        public async Task Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = await unitOfWork.GetReadRepository<Category>()
                .GetAsync(c => c.Id == request.Id && !c.IsDeleted);

            Category mapedData = mapper.Map<Category, UpdateCategoryCommandRequest>(request);

            var entity = await unitOfWork.GetWriteRepository<Category>().UpdateAsync(mapedData);
        }
    }
}