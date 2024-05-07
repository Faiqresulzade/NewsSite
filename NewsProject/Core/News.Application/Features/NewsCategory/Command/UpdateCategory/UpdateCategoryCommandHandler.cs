using MediatR;
using News.Application.Abstraction.Interfaces.AutoMapper;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Classes;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Command.UpdateCategory
{
    internal class UpdateCategoryCommandHandler : UpdateCommandHandler, IRequestHandler<UpdateCategoryCommandRequest>
    {
        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper) { }

        public async Task Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category =await unitOfWork.GetReadRepository<Category>()
                .GetAsync(c => c.Id == request.Id && !c.IsDeleted);

            Category mapedData = mapper.Map<Category, UpdateCategoryCommandRequest>(request);

            await unitOfWork.GetWriteRepository<Category>().UpdateAsync(mapedData);
            await unitOfWork.SaveAsync();
        }
    }
}