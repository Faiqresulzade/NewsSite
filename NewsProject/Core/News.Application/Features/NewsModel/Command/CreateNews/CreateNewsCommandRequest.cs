using MediatR;
using Microsoft.AspNetCore.Http;
using News.Application.DTOs.News;

namespace News.Application.Features.NewsModel.Command.CreateNews
{
    public record CreateNewsCommandRequest : IRequest<Unit>
    {
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public IFormFile NewsImage { get; set; }

        public static implicit operator NewsCreateDto(CreateNewsCommandRequest request)
        {
            return new()
            {
                AuthorName = request.AuthorName,
                Title = request.Title,
                CategoryId = request.CategoryId,
                Description = request.Description,
                NewsImage = request.NewsImage,
            };
        }
    }
}
