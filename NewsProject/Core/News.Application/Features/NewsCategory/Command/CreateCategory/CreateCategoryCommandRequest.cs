using MediatR;

namespace News.Application.Features.NewsCategory.Command.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest
    {
        public string Name { get; set; }
    }
}
