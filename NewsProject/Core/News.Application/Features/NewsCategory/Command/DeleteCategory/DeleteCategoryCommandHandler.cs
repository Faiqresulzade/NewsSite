using MediatR;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Classes;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Command.DeleteCategory
{
    internal class DeleteCategoryCommandHandler : DeleteCommandHandler, IRequestHandler<DeleteCategoryCommandRequest>
    {
        public DeleteCategoryCommandHandler(in IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
          => await base.SoftDelete<Category>(request.Id);

    }
}