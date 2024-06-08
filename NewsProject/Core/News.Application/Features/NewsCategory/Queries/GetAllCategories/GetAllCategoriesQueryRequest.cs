using MediatR;

namespace News.Application.Features.NewsCategory.Queries.GetAllCategories
{
    public record GetAllCategoriesQueryRequest : IRequest<IList<GetAllCategoriesQueryResponse>>
    {
    }
}
