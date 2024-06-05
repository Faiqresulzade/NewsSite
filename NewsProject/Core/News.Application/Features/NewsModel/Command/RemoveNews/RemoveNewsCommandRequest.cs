using MediatR;

namespace News.Application.Features.NewsModel.Command.RemoveNews
{
    public class RemoveNewsCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
