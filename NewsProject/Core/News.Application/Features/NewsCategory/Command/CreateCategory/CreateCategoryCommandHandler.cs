using MediatR;
using News.Application.Abstraction.Interfaces.Factories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Classes.Command;
using News.Application.Extensions.UnitOfWorks;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Command.CreateCategory
{
    /// <summary>
    /// Handler for creating a news category, responsible for processing the creation request and interacting with the data layer.
    /// </summary>

    public class CreateCategoryCommandHandler : CreateCommandHandler<ICategoryFactory>, IRequestHandler<CreateCategoryCommandRequest>
    {
        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryFactory factory)
        : base(unitOfWork, factory) { }


        public async Task Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
         => await unitOfWork.AddAsync<Category, ICategoryFactory, CreateCategoryCommandRequest>(factory, request);

    }
}