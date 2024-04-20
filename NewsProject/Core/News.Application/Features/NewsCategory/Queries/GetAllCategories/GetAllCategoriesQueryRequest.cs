using MediatR;

namespace News.Application.Features.NewsCategory.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryRequest : IRequest<IList<GetAllCategoriesQueryResponse>>
    {
    }
}
