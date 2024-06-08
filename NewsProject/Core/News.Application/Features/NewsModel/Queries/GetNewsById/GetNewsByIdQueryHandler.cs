using MediatR;
using News.Application.Bases.Classes.Query;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using NewsEntity = News.Domain.Entities.News;

namespace News.Application.Features.NewsModel.Queries.GetNewsById
{
    internal class GetNewsByIdQueryHandler : GetQueryHandler, IRequestHandler<GetNewsByIdQueryRequest, GetNewsByIdQueryResponse>
    {
        public static event Func<IList<NewsEntity>, int, NewsEntity>? OnNewsGet;

        public GetNewsByIdQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<GetNewsByIdQueryResponse> Handle(GetNewsByIdQueryRequest request, CancellationToken cancellationToken)
        {
            IList<NewsEntity> listOfNews = await unitOfWork.GetReadRepository<NewsEntity>().GetAllAsync(x => !x.IsDeleted);

            NewsEntity? news = OnNewsGet?.Invoke(listOfNews, request.Id);

            return await base.GetEntity<GetNewsByIdQueryResponse, NewsEntity>(request.Id,news);
        }
    }
}
