using MediatR;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Classes.Query;
using News.Application.Features.NewsCategory.Rules;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Queries.GetCategoryById
{
    /// <summary>
    /// Handler for retrieving a specific news category by its ID, responsible for processing the request and interacting with the data layer to fetch the category.
    /// </summary>

    public class GetCategoryQueryHandler : GetQueryHandler, IRequestHandler<GetCategoryQueryRequest, GetCategoryQueryResponse>
    {
        private readonly NewsCategoryRules _rules;

        public GetCategoryQueryHandler(IUnitOfWork unitOfWork, NewsCategoryRules rules) : base(unitOfWork)
        {
            _rules = rules;
        }

        async Task<GetCategoryQueryResponse> IRequestHandler<GetCategoryQueryRequest, GetCategoryQueryResponse>.Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            IList<Category> categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync();
            Category category = _rules.FindCategory(categories, request.Id);

            return await base.GetEntity<GetCategoryQueryResponse, Category>(request.Id, category);
        }
    }
}