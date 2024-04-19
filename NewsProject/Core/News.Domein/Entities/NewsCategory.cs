using News.Domain.Comman;

namespace News.Domain.Entities
{
    /// <summary>
    /// Represents a category under which news articles are classified.
    /// </summary>
    public sealed class NewsCategory : EntityBase
    {
        public string Name { get; set; }
        public IList<News> News { get; set; }

        public NewsCategory()
        {

        }

        public NewsCategory(string name) => Name = name;
    }
}
