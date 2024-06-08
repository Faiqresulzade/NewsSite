using MediatR;

namespace News.Application.Features.NewsModel.Queries.GetAllNews
{
    public record GetAllNewsQueryRequest : IRequest<IList<GetAllNewsQueryResponse>>
    {
    }
}
