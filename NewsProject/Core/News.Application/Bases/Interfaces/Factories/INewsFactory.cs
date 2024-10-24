using News.Application.Abstraction.Interfaces.Factories;
using News.Application.Features.NewsModel.Command.CreateNews;
using NewsEntity = News.Domain.Entities.News;
using News.Application.DTOs.News;

namespace News.Application.Bases.Interfaces.Factories
{
    public interface INewsFactory : IFactory<NewsEntity, NewsCreateDto>
    {

    }
}
