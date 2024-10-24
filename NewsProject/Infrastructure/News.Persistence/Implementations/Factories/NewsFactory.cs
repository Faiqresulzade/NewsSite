using MediatR;
using News.Application.DTOs.News;
using News.Application.Bases.Interfaces.Factories;
using NewsEntity = News.Domain.Entities.News;
using News.Application.Utilities.Helpers;
using ServicesRegisterPlugin.Atributes;

namespace News.Persistence.Implementations.Factories
{
    [Scoped(nameof(INewsFactory))]
    public class NewsFactory : INewsFactory
    {
        public async Task<NewsEntity> Create(NewsCreateDto trequest)
        {
            return new NewsEntity(trequest.AuthorName,
                   trequest.Title, trequest.Description, trequest.CategoryId,
                  await FileHelper.Instance.Upload(trequest.NewsImage));
        }
    }
}
