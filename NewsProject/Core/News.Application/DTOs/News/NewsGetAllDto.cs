using News.Application.Features.NewsModel.Queries.GetAllNews;
using NewsEntity = News.Domain.Entities.News;

namespace News.Application.DTOs.News
{
    /// <summary>
    /// DTO class for getting all news with query responses.
    /// </summary>
    public class NewsGetAllDto
    {
        /// <summary>
        /// List of query responses for all news.
        /// </summary>
        public List<GetAllNewsQueryResponse> GetAllNewsQueryResponses { get; private set; } = new();
        

        /// <summary>
        /// Implicitly converts a list of NewsEntity to NewsGetAllDto.
        /// </summary>
        /// <param name="news">List of NewsEntity objects.</param>
        public static implicit operator NewsGetAllDto(List<NewsEntity> news)
        {
            NewsGetAllDto newsGetAllDto = new NewsGetAllDto();

            foreach (NewsEntity item in news)
            {
                GetAllNewsQueryResponse response = new()
                {
                    AuthorName = item.AuthorName,
                    Title = item.Title,
                    Description = item.Description,
                    CategoryName = item.Category.Name,
                    CategoryId = item.CategoryId,
                    ImagePath = item.ImagePath,
                    ReadCount = item.ReadCount,
                    Id = item.Id
                };
                newsGetAllDto.GetAllNewsQueryResponses.Add(response);
            }

            return newsGetAllDto;
        }
    }
}