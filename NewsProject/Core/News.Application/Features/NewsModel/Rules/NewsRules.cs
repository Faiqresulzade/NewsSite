using Microsoft.AspNetCore.Http;
using News.Application.Utilities.Helpers;
using News.Application.Bases.Classes.Rules;
using News.Application.Bases.Interfaces.Rules;
using News.Application.Features.NewsModel.Command.UpdateNews;
using News.Application.Features.NewsModel.Exceptions;
using NewsEntity = News.Domain.Entities.News;
using News.Application.Bases.Interfaces.DI;

namespace News.Application.Features.NewsModel.Rules
{
    public class NewsRules : BaseRules<NewsEntity>, INewsRules,ITransient
    {
        public void PropertyIsNotImage(IFormFile newsImage)
        {
            if (!FileHelper.Instance.IsImage(newsImage)) throw new PropertyIsNotImageException();
        }

        public bool CheckImage(UpdateNewsCommandRequest request)
        {
            if (request.NewsImage != null)
                PropertyIsNotImage(request.NewsImage);

            return request.NewsImage != null;
        }

        public NewsEntity FindNews(IList<NewsEntity> news, int id)
        {
            NewsEntity? newsEntity = news.FirstOrDefault(c => c.Id == id && !c.IsDeleted);

            return base.EntityNotFound(newsEntity);
        }
    }
}