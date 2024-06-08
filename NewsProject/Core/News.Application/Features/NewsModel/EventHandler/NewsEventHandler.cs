using News.Application.Bases.Interfaces.DI;
using News.Application.Bases.Interfaces.Rules;
using News.Application.Features.NewsModel.Command.CreateNews;
using News.Application.Features.NewsModel.Command.UpdateNews;
using News.Application.Features.NewsModel.Queries.GetNewsById;
using News.Domain.Entities;
using Category = News.Domain.Entities.NewsCategory;
using NewsEntity = News.Domain.Entities.News;

namespace News.Application.Features.NewsModel.EventHandler
{
    public class NewsEventHandler : ITransient
    {
        private readonly INewsRules _newsRules;
        private readonly INewsCategoryRules _newsCategoryRules;

        public NewsEventHandler(INewsRules newsRules, INewsCategoryRules newsCategoryRules)
          => (_newsRules, _newsCategoryRules) = (newsRules, newsCategoryRules);

        public void SubscripeToEvent()
        {
            CreateNewsCommandHandler.OnNewsCreate += OnNewsCreate;
            UpdateNewsCommandHandler.OnNewsUpdate += OnNewsUpdate;
            GetNewsByIdQueryHandler.OnNewsGet += OnNewsGet;
        }

        private NewsEntity OnNewsGet(IList<NewsEntity> listOfNews, int id)
        {
           return _newsRules.FindNews(listOfNews,id);
        }

        private (bool, NewsEntity) OnNewsUpdate(UpdateNewsCommandRequest request, IList<NewsEntity> listOfNews)
        {
            bool isSuccess = _newsRules.CheckImage(request);
            var news = _newsRules.FindNews(listOfNews, request.Id);

            return (isSuccess, news);
        }

        private Category OnNewsCreate(CreateNewsCommandRequest request, IList<Category> categories)
        {
            _newsRules.PropertyIsNotImage(request.NewsImage);
            return _newsCategoryRules.FindCategory(categories, request.CategoryId);
        }

        public void UnSubscripeFromEvent()
        {
            CreateNewsCommandHandler.OnNewsCreate -= OnNewsCreate;
            UpdateNewsCommandHandler.OnNewsUpdate -= OnNewsUpdate;

        }

        ~NewsEventHandler()
        => UnSubscripeFromEvent();

    }
}