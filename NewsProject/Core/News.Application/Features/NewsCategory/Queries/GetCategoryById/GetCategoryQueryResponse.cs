namespace News.Application.Features.NewsCategory.Queries.GetCategoryById
{
    public record GetCategoryQueryResponse
    {
        public int Id { get; }
        public string Name { get; }
    }
}