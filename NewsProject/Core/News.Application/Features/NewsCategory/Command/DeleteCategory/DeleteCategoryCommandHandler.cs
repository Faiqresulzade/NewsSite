using MediatR;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Classes.Command;
using News.Application.Bases.Interfaces.Rules;
using News.Domain.Comman;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Command.DeleteCategory
{
    /// <summary>
    /// Handler for deleting a news category, responsible for processing the deletion request and interacting with the data layer.
    /// </summary>

    internal class DeleteCategoryCommandHandler : DeleteCommandHandler, IRequestHandler<DeleteCategoryCommandRequest, Unit>
    {
        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
          => await base.Delete<Category>(request.Id);
    }
}