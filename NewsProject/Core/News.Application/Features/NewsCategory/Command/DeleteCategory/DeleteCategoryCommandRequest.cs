
using MediatR;

namespace News.Application.Features.NewsCategory.Command.DeleteCategory
{
    public class DeleteCategoryCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
