namespace News.Application.Features.NewsModel.Queries.GetAllNews
{
    public class GetAllNewsQueryResponse
    {
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReadCount { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
