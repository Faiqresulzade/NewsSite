using MediatR;
using News.Application.Bases.Classes.Query;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Queries.GetCategoryById
{
    /// <summary>
    /// Handler for retrieving a specific news category by its ID, responsible for processing the request and interacting with the data layer to fetch the category.
    /// </summary>

    internal class GetCategoryQueryHandler : GetQueryHandler, IRequestHandler<GetCategoryQueryRequest, GetCategoryQueryResponse>
    {
        public static event Func<IList<Category>,int, Category>? OnCategoryGet;

        public GetCategoryQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        async Task<GetCategoryQueryResponse> IRequestHandler<GetCategoryQueryRequest, GetCategoryQueryResponse>.Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            IList<Category> categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync(x=>!x.IsDeleted);

            Category? category = OnCategoryGet?.Invoke(categories, request.Id);

            return await base.GetEntity<GetCategoryQueryResponse, Category>(request.Id, category);
        }
    }
}