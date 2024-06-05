using MediatR;
using News.Application.Bases.Classes.Command;
using News.Application.Bases.Interfaces.Services;
using News.Application.Bases.Interfaces.Factories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using Category = News.Domain.Entities.NewsCategory;
using NewsEntity = News.Domain.Entities.News;
using News.Application.Bases.Interfaces.Helpers;
using News.Application.Utilities.Helpers;

namespace News.Application.Features.NewsModel.Command.CreateNews
{
    public class CreateNewsCommandHandler : CreateCommandHandler<INewsFactory>, IRequestHandler<CreateNewsCommandRequest, Unit>
    {
        private readonly ICategoryService _categoryService;

        public static event Func<CreateNewsCommandRequest, IList<Category>, Category>? OnNewsCreate;
        public CreateNewsCommandHandler(IUnitOfWork unitOfWork, ICategoryService categoryService, INewsFactory factory) : base(unitOfWork, factory)
        {
            _categoryService = categoryService;
        }

        public async Task<Unit> Handle(CreateNewsCommandRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetAllCategory();
            _ = OnNewsCreate?.Invoke(request, categories);
            await FileHelper.Instance.Upload(request.NewsImage);

            await base.AddAsync<NewsEntity, INewsFactory, CreateNewsCommandRequest>(unitOfWork, factory, request);

            return default;
        }
    }
}