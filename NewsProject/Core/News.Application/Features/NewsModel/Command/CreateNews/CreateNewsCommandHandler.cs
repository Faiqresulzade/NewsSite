using MediatR;
using News.Application.Bases.Classes.Command;
using News.Application.Bases.Interfaces.Factories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using Category = News.Domain.Entities.NewsCategory;
using NewsEntity = News.Domain.Entities.News;
using News.Application.DTOs.News;

namespace News.Application.Features.NewsModel.Command.CreateNews
{
    internal class CreateNewsCommandHandler : CreateCommandHandler<NewsEntity, INewsFactory, NewsCreateDto>, IRequestHandler<CreateNewsCommandRequest, Unit>
    {
        public static event Func<CreateNewsCommandRequest, IList<Category>, Category>? OnNewsCreate;
        public CreateNewsCommandHandler(IUnitOfWork unitOfWork, INewsFactory factory) : base(unitOfWork, factory) { }

        public async Task<Unit> Handle(CreateNewsCommandRequest request, CancellationToken cancellationToken)
        {
            NewsCreateDto newsCreateDto = request;

            IList<Category> categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            _ = OnNewsCreate?.Invoke(request, categories);

            await base.AddAsync(unitOfWork, factory, newsCreateDto);

            return default;
        }
    }
}