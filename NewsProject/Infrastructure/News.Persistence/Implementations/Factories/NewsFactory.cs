using MediatR;
using News.Application.DTOs.News;
using News.Application.Bases.Interfaces.DI;
using News.Application.Bases.Interfaces.Factories;
using NewsEntity = News.Domain.Entities.News;
using News.Application.Utilities.Helpers;

namespace News.Persistence.Implementations.Factories
{
    public class NewsFactory : IScoped, INewsFactory
    {
        public async Task<NewsEntity> Create(NewsCreateDto trequest)
        {
            return new NewsEntity(trequest.AuthorName,
                   trequest.Title, trequest.Description, trequest.CategoryId,
                  await FileHelper.Instance.Upload(trequest.NewsImage));
        }
    }
}
