using MediatR;
using Microsoft.AspNetCore.Http;
using NewsEntity = News.Domain.Entities.News;

namespace News.Application.Features.NewsModel.Command.UpdateNews
{
    public record UpdateNewsCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public IFormFile? NewsImage { get; set; }
    }
}
