
using MediatR;

namespace News.Application.Features.NewsCategory.Command.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
