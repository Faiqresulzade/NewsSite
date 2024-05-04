using MediatR;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Classes;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler : DeleteCommandHandler, IRequestHandler<DeleteCategoryCommandRequest>
    {
        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = await unitOfWork.GetReadRepository<Category>()
               .GetAsync(c => c.Id == request.Id && !c.IsDeleted);

            category.IsDeleted = true;

            await unitOfWork.GetWriteRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveAsync();
        }
    }
}
