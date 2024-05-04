
using MediatR;

namespace News.Application.Features.NewsCategory.Command.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
