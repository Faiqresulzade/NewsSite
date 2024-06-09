using MediatR;
using Microsoft.EntityFrameworkCore;
using News.Application.Bases.Classes.Query;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using NewsEntity = News.Domain.Entities.News;
using News.Domain.Entities;
using News.Application.Bases.Interfaces.Services.News;

namespace News.Application.Features.NewsModel.Queries.GetNewsById
{
    internal class GetNewsByIdQueryHandler : GetQueryHandler<GetNewsByIdQueryResponse, NewsEntity>, IRequestHandler<GetNewsByIdQueryRequest, GetNewsByIdQueryResponse>
    {
        public static event Func<IList<NewsEntity>, int, NewsEntity>? OnNewsGet;
        private readonly IReadCountİncrementable _newsReadCountİncrementable;

        public GetNewsByIdQueryHandler(IUnitOfWork unitOfWork, IReadCountİncrementable newsReadCountİncrementable) : base(unitOfWork)
        {
            _newsReadCountİncrementable = newsReadCountİncrementable;
        }

        public async Task<GetNewsByIdQueryResponse> Handle(GetNewsByIdQueryRequest request, CancellationToken cancellationToken)
        {
            IList<NewsEntity> listOfNews = await unitOfWork.GetReadRepository<NewsEntity>()
                .GetAllAsync(x => !x.IsDeleted, include: query => query.Include(news => news.Category));

            NewsEntity? news = OnNewsGet?.Invoke(listOfNews, request.Id);
            await _newsReadCountİncrementable.IncrementReadCount(news, unitOfWork);

            return await this.GetEntity(request.Id, news);
        }
        private protected override async Task<GetNewsByIdQueryResponse> GetEntity
            (int id, NewsEntity? entity, Action<GetNewsByIdQueryResponse> customMap = default)
        {
            GetNewsByIdQueryResponse response = entity;
            return response;
        }
    }
}