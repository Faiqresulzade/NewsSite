using MediatR;
using Microsoft.AspNetCore.Http;
using NewsEntity = News.Domain.Entities.News;

namespace News.Application.Features.NewsModel.Command.UpdateNews
{
    public class UpdateNewsCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public int ReadCount { get; set; }
        //public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public IFormFile? NewsImage { get; set; }

        public static implicit operator NewsEntity(UpdateNewsCommandRequest request)
        {
            return new NewsEntity()
            {
                Id = request.Id,
                AuthorName = request.AuthorName,
                Title = request.Title,
                Description = request.Description,
                CategoryId = request.CategoryId,
            };
        }
    }
}
