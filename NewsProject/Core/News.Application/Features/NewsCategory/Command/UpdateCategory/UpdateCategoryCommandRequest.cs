using MediatR;
using Category = News.Domain.Entities.NewsCategory;

namespace News.Application.Features.NewsCategory.Command.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Performs an implicit conversion from <see cref="UpdateCategoryCommandRequest"/> to <see cref="Category"/>.
        /// </summary>
        /// <param name="request">The <see cref="UpdateCategoryCommandRequest"/> instance to convert.</param>
        /// <returns>A new instance of <see cref="Category"/> with values copied from the <see cref="UpdateCategoryCommandRequest"/> instance.</returns>
        public static implicit operator Category(UpdateCategoryCommandRequest request)
        {
            return new Category
            {
                Id = request.Id,
                Name = request.Name
            };
        }
    }
}