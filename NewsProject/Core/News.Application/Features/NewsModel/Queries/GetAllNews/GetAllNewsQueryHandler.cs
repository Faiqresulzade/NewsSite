using MediatR;
using Microsoft.EntityFrameworkCore;
using News.Application.Bases.Classes.Query;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using GetAllNewsQueryResponseType = News.Application.Features.NewsModel.Queries.GetAllNews.GetAllNewsQueryResponse;
using NewsEntity = News.Domain.Entities.News;

namespace News.Application.Features.NewsModel.Queries.GetAllNews
{
    public class GetAllNewsQueryHandler : GetAllQueryHandler, IRequestHandler<GetAllNewsQueryRequest, IList<GetAllNewsQueryResponse>>
    {
        public GetAllNewsQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        Task<IList<GetAllNewsQueryResponse>> IRequestHandler<GetAllNewsQueryRequest, IList<GetAllNewsQueryResponse>>.Handle(GetAllNewsQueryRequest request, CancellationToken cancellationToken)
        => this.GetAllEntity<GetAllNewsQueryResponse, NewsEntity>();

        private protected async override Task<IList<TResponse>> GetAllEntity<TResponse, Tentity>()
        {
            IList<NewsEntity> entities = await unitOfWork.GetReadRepository<NewsEntity>().GetAllAsync(
                predicate: n => !n.IsDeleted,
                include: query => query.Include(news => news.Category));

            IList<GetAllNewsQueryResponseType> mappedData = mapper.Map<GetAllNewsQueryResponseType, NewsEntity>(entities);

            for (int i = 0; i < mappedData.Count; i++)
                mappedData[i].CategoryName = entities[i].Category.Name;

            return (IList<TResponse>)mappedData;
        }
    }
}