using MediatR;
using Microsoft.EntityFrameworkCore;
using News.Application.Bases.Classes.Query;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using NewsEntity = News.Domain.Entities.News;
using News.Application.DTOs.News;

namespace News.Application.Features.NewsModel.Queries.GetAllNews
{
    internal class GetAllNewsQueryHandler : GetAllQueryHandler, IRequestHandler<GetAllNewsQueryRequest, IList<GetAllNewsQueryResponse>>
    {
        public GetAllNewsQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public Task<IList<GetAllNewsQueryResponse>> Handle(GetAllNewsQueryRequest request, CancellationToken cancellationToken)
          => this.GetAllEntity<GetAllNewsQueryResponse, NewsEntity>();

        private protected async override Task<IList<TResponse>> GetAllEntity<TResponse, Tentity>()
        {
            IList<NewsEntity> entities = await unitOfWork.GetReadRepository<NewsEntity>().GetAllAsync(
                predicate: n => !n.IsDeleted,
                include: query => query.Include(news => news.Category));

            NewsGetAllDto newsGetAllDto = entities.ToList();

            return (IList<TResponse>)newsGetAllDto.GetAllNewsQueryResponses;
        }
    }
}