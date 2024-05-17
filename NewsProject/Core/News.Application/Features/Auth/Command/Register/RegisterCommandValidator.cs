using FluentValidation;

namespace News.Application.Features.Auth.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(20)
                .MinimumLength(2)
                .WithName("Ad");

            RuleFor(x => x.Surname)
                 .NotEmpty()
                 .MaximumLength(20)
                 .MinimumLength(2)
                 .WithName("Soyad");

            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(40)
                .MinimumLength(6)
                .EmailAddress()
                .WithName("Gmail adressi");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .WithName("giriş kodu");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .MinimumLength(6)
                .Equal(x => x.Password)
                .WithName("giriş kodu təkrarı")
                .WithMessage("kod ilə kod təkrarı eyni deyil! ");
        }
    }
}
