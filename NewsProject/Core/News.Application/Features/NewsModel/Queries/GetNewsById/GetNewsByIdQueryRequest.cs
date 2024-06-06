using MediatR;

namespace News.Application.Features.NewsModel.Queries.GetNewsById
{
    public record GetNewsByIdQueryRequest : IRequest<GetNewsByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
