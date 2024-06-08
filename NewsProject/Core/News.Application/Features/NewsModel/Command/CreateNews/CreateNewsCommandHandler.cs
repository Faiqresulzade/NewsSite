using MediatR;
using News.Application.Bases.Classes.Command;
using News.Application.Bases.Interfaces.Services;
using News.Application.Bases.Interfaces.Factories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using Category = News.Domain.Entities.NewsCategory;
using NewsEntity = News.Domain.Entities.News;
using News.Application.Utilities.Helpers;
using News.Application.Abstraction.Interfaces.Repositories;

namespace News.Application.Features.NewsModel.Command.CreateNews
{
    internal class CreateNewsCommandHandler : CreateCommandHandler<NewsEntity, INewsFactory, CreateNewsCommandRequest>, IRequestHandler<CreateNewsCommandRequest, Unit>
    {
        private readonly ICategoryService _categoryService;

        private string _filePath;

        public static event Func<CreateNewsCommandRequest, IList<Category>, Category>? OnNewsCreate;
        public CreateNewsCommandHandler(IUnitOfWork unitOfWork, ICategoryService categoryService, INewsFactory factory) : base(unitOfWork, factory)
        {
            _categoryService = categoryService;
        }

        public async Task<Unit> Handle(CreateNewsCommandRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetAllCategory();
            _ = OnNewsCreate?.Invoke(request, categories);
            _filePath = await FileHelper.Instance.Upload(request.NewsImage);

            await this.AddAsync(unitOfWork, factory, request);

            return default;
        }

        protected async override Task<NewsEntity> AddAsync
        (IUnitOfWork unitOfWork, INewsFactory factory, CreateNewsCommandRequest request, IWriteRepository<NewsEntity> repository = null)
        {
            NewsEntity entity = await factory.Create(request);
            repository = unitOfWork.GetWriteRepository<NewsEntity>();
          
            //dto istifade etmek lazimdir.factory dto alacaq parametr olaraq
            entity.ImagePath = _filePath;

            await repository.AddAsync(entity);
            await repository.SaveAsync();

            return entity;
        }
    }
}