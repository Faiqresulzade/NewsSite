using FluentValidation;

namespace News.Application.Features.NewsCategory.Command.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommandRequest>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
              .GreaterThan(0)
              .WithName("Id");

            RuleFor(x => x.Name)
              .NotEmpty()
              .WithName("Kategoriya adı");
        }

    }
}
