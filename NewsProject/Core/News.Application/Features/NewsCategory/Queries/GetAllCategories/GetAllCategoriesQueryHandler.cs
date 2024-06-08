using MediatR;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Classes.Query;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Queries.GetAllCategories
{
    /// <summary>
    /// Handler for retrieving all news categories, responsible for processing the request and interacting with the data layer to fetch all categories.
    /// </summary>

    internal class GetAllCategoriesQueryHandler : GetAllQueryHandler, IRequestHandler<GetAllCategoriesQueryRequest, IList<GetAllCategoriesQueryResponse>>
    {
        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<IList<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
          => await base.GetAllEntity<GetAllCategoriesQueryResponse, Category>();

    }
}