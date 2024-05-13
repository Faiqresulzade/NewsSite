using MediatR;

namespace News.Application.Features.NewsCategory.Queries.GetCategoryById
{
    public class GetCategoryQueryRequest : IRequest<GetCategoryQueryResponse>
    {
        public int Id { get; }
    }
}
