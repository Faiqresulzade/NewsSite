using Microsoft.AspNetCore.Http;
using News.Application.Bases.Interfaces.DI;
using News.Application.Features.NewsModel.Command.UpdateNews;
using NewsEntity = News.Domain.Entities.News;

namespace News.Application.Bases.Interfaces.Rules
{
    public interface INewsRules : IDependencyInjections, IBaseRule<NewsEntity>
    {
        void PropertyIsNotImage(IFormFile newsImage);
        bool CheckImage(UpdateNewsCommandRequest request);
        NewsEntity FindNews(IList<NewsEntity> news, int id);
    }
}
