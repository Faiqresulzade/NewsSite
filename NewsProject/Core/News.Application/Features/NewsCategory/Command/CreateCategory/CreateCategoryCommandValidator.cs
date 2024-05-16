using FluentValidation;

namespace News.Application.Features.NewsCategory.Command.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithName("Kategoriya adı");
        }
    }
}
