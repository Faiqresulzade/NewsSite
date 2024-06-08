using MediatR;
using Microsoft.EntityFrameworkCore;
using News.Application.Bases.Classes.Query;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using NewsEntity = News.Domain.Entities.News;
using News.Domain.Entities;

namespace News.Application.Features.NewsModel.Queries.GetNewsById
{
    internal class GetNewsByIdQueryHandler : GetQueryHandler, IRequestHandler<GetNewsByIdQueryRequest, GetNewsByIdQueryResponse>
    {
        public static event Func<IList<NewsEntity>, int, NewsEntity>? OnNewsGet;

        public GetNewsByIdQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<GetNewsByIdQueryResponse> Handle(GetNewsByIdQueryRequest request, CancellationToken cancellationToken)
        {
            IList<NewsEntity> listOfNews = await unitOfWork.GetReadRepository<NewsEntity>().GetAllAsync(x => !x.IsDeleted, include: query => query.Include(news => news.Category));

            NewsEntity? news = OnNewsGet?.Invoke(listOfNews, request.Id);

            GetNewsByIdQueryResponse entity = await base.GetEntity<GetNewsByIdQueryResponse, NewsEntity>(request.Id, news, (entity) => CustomMap(entity, news));

            return entity;
        }

        private void CustomMap(GetNewsByIdQueryResponse entity, NewsEntity news)
        => entity.CategoryName = news.Category.Name;
    }
}