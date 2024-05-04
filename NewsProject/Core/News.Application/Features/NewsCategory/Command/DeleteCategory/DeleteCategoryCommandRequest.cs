
using MediatR;

namespace News.Application.Features.NewsCategory.Command.DeleteCategory
{
    public class DeleteCategoryCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}
