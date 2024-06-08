
using MediatR;

namespace News.Application.Features.NewsCategory.Command.DeleteCategory
{
    public record DeleteCategoryCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
