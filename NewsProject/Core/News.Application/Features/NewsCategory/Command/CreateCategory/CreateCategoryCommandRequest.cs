using MediatR;

namespace News.Application.Features.NewsCategory.Command.CreateCategory
{
    public record CreateCategoryCommandRequest : IRequest<Unit>
    {
        public string Name { get; set; }
    }
}
