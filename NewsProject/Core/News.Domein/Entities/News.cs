using News.Domain.Comman;

namespace News.Domain.Entities
{
    /// <summary>
    /// Entity representing a news class.
    /// </summary>
    public sealed class News : EntityBase
    {
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReadCount { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public NewsCategory Category { get; set; }

        public News() { }

        public News(string authorName, string title, string description, int categoryId, string filePath)
        {
            CategoryId = categoryId;
            AuthorName = authorName;
            Title = title;
            Description = description;
            ImagePath = filePath;
        }
    }
}