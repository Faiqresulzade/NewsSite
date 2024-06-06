using MediatR;
using Microsoft.AspNetCore.Http;

namespace News.Application.Features.NewsModel.Command.CreateNews
{
    public record CreateNewsCommandRequest : IRequest<Unit>
    {
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public IFormFile NewsImage { get; set; }
    }
}
