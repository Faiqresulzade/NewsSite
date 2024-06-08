using FluentValidation;

namespace News.Application.Features.NewsModel.Command.RemoveNews
{
    public class RemoveNewsCommandValidator : AbstractValidator<RemoveNewsCommandRequest>
    {
        public RemoveNewsCommandValidator()
        {
            RuleFor(news => news.Id)
               .GreaterThan(0);
        }
    }
}
