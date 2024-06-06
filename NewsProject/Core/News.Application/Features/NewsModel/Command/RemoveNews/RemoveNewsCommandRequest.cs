using MediatR;

namespace News.Application.Features.NewsModel.Command.RemoveNews
{
    public record RemoveNewsCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
