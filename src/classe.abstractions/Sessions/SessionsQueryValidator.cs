using FluentValidation;

namespace ClassE.Sessions
{
    internal class SessionsQueryValidator : AbstractValidator<SessionsQuery>
    {
        public SessionsQueryValidator(Validators.QueryValidator queryValidator)
        {
            Include(queryValidator);

            RuleFor(m => m.StartDate)
                .LessThanOrEqualTo(m => m.EndDate)
                .When(m => m.EndDate.HasValue);

            RuleFor(m => m.EndDate)
                .GreaterThanOrEqualTo(m => m.StartDate)
                .When(m => m.StartDate.HasValue);
        }
    }
}