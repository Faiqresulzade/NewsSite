using FluentValidation;
using MediatR;

namespace News.Application.Beheviors
{
    /// <summary>
    /// Provides a behavior for handling FluentValidation within MediatR pipelines.
    /// </summary>
    /// <typeparam name="Trequest">The type of the request.</typeparam>
    /// <typeparam name="Tresponse">The type of the response.</typeparam>
    public class FluentValidationBehevior<Trequest, Tresponse> : IPipelineBehavior<Trequest, Tresponse>
        where Trequest : IRequest<Tresponse>
    {
        private readonly IEnumerable<IValidator<Trequest>> _validators;

        public FluentValidationBehevior(IEnumerable<IValidator<Trequest>> validators)
           => _validators = validators;

        public Task<Tresponse> Handle(Trequest request, RequestHandlerDelegate<Tresponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<Trequest>(request);
            var failtures = _validators
                .Select(validator => validator.Validate(context))
                .SelectMany(result => result.Errors)
                .GroupBy(x => x.ErrorMessage)
                .Select(x => x.First())
                .Where(f => f != null)
                .ToList();

            if (failtures.Any()) throw new ValidationException(failtures);

            return next();
        }
    }
}
