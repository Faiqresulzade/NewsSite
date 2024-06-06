using News.Application.Bases.Interfaces.DI;
using News.Application.Bases.Interfaces.Factories;
using News.Application.Features.NewsModel.Command.CreateNews;
using NewsEntity = News.Domain.Entities.News;

namespace News.Persistence.Factories
{
    public class NewsFactory : IScoped, INewsFactory
    {
        public async Task<NewsEntity> Create(CreateNewsCommandRequest trequest)
        => new NewsEntity(trequest.AuthorName, trequest.Title, trequest.Description, trequest.CategoryId);
    }
}
