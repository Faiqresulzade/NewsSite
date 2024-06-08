using Microsoft.AspNetCore.Http;

namespace News.Application.DTOs.News
{
    public record NewsCreateDto
    {
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public IFormFile NewsImage { get; set; }

        public string FilePath { get; set; }
    }
}
