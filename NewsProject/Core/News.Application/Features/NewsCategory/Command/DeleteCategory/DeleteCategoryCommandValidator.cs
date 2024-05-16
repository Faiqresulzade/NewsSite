using FluentValidation;

namespace News.Application.Features.NewsCategory.Command.DeleteCategory
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommandRequest>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
               .GreaterThan(0)
               .WithName("Id");
        }
    }
}
