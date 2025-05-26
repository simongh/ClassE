using FluentValidation;
using MediatR;

namespace ClassE.Behaviours
{
    internal class ValidationBehaviour<TRequest, TResult>(IEnumerable<AbstractValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, TResult> where TRequest : notnull
    {
        private readonly IEnumerable<AbstractValidator<TRequest>> _validators = validators;

        public async Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(
                    _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                var failures = validationResults
                    .Where(e => e.Errors.Any())
                    .SelectMany(e => e.Errors)
                    .ToArray();

                if (failures.Any())
                {
                    throw new ValidationException(failures);
                }
            }

            return await next();
        }
    }
}