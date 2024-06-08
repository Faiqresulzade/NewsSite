using NewsEntity = News.Domain.Entities.News;

namespace News.Application.Features.NewsModel.Queries.GetAllNews
{
    public record GetAllNewsQueryResponse
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReadCount { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        //public static implicit operator List<GetAllNewsQueryResponse>(List<NewsEntity> news)
        //{
        //return type dto olmalidir. 
        //    return default;
        //}
    }
}
