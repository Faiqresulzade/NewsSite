using MediatR;

namespace News.Application.Features.NewsCategory.Queries.GetCategoryById
{
    public record GetCategoryQueryRequest : IRequest<GetCategoryQueryResponse>
    {
        public int Id { get; }
    }
}
