using MediatR;
using News.Application.Abstraction.Interfaces.AutoMapper;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Classes.Query;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Queries.GetCategoryById
{
    public class GetCategoryQueryHandler : GetQueryHandler, IRequestHandler<GetCategoryQueryRequest, GetCategoryQueryResponse>
    {
        public GetCategoryQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        async Task<GetCategoryQueryResponse> IRequestHandler<GetCategoryQueryRequest, GetCategoryQueryResponse>.Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
         => await base.GetEntity<GetCategoryQueryResponse, Category>(request.Id);
    }
}