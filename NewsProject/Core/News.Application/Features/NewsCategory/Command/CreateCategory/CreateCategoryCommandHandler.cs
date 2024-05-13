using MediatR;
using News.Application.Abstraction.Interfaces.Factories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Classes;
using News.Application.Bases.Classes.Command;
using News.Application.Extensions.UnitOfWorks;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Command.CreateCategory
{
    public class CreateCategoryCommandHandler : CreateCommandHandler<ICategoryFactory>, IRequestHandler<CreateCategoryCommandRequest>
    {
        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryFactory factory)
        : base(unitOfWork, factory) { }


        public async Task Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
         => await unitOfWork.AddAsync<Category, ICategoryFactory, CreateCategoryCommandRequest>(factory, request);

    }
}