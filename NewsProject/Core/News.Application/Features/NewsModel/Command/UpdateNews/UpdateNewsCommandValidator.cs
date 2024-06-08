using FluentValidation;

namespace News.Application.Features.NewsModel.Command.UpdateNews
{
    public class UpdateNewsCommandValidator : AbstractValidator<UpdateNewsCommandRequest>
    {
        public UpdateNewsCommandValidator()
        {
            RuleFor(x => x.Id)
              .GreaterThan(0)
              .WithName("Id");

            RuleFor(x => x.AuthorName)
              .NotEmpty()
              .WithMessage("Yazar adı boş olmamalıdır.")
              .WithName("Yazar adı");

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Başlıq boş olmamalıdır.")
                .WithName("Başlıq");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Açıqlama boş olmamalıdır.")
                .WithName("Açıqlama")
                .MaximumLength(1000)
                .WithMessage("Açıqlama ən çox 1000 xarakter olmalıdır.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0)
                .WithMessage("keçərli bir kategoriya seçilməlidir.")
                .WithName("Kategoriya");

            RuleFor(x => x.NewsImage)
                .NotNull()
                .WithMessage("Bir şəkil yükləməlisiniz.")
                .WithName("Xəbər şəkili")
                .When(x => x.NewsImage != null);
        }
    }
}
