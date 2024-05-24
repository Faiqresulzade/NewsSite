using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static implicit operator Category(GetAllCategoriesQueryResponse response)
        {
            return new Category()
            {
                Id = response.Id,
                Name = response.Name
            };
        }
    }
}
