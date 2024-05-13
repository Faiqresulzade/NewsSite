using MediatR;
using News.Application.Abstraction.Interfaces.AutoMapper;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Classes.Query;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : GetAllQueryHandler, IRequestHandler<GetAllCategoriesQueryRequest, IList<GetAllCategoriesQueryResponse>>
    {
        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<IList<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
          => await base.GetAllEntity<GetAllCategoriesQueryResponse, Category>();

    }
}