using FluentValidation;

namespace ClassE.Validators
{
    internal class QueryValidator : AbstractValidator<Types.BaseQuery>
    {
        public QueryValidator()
        {
            RuleFor(m => m.Offset)
                .GreaterThanOrEqualTo(0);

            RuleFor(m => m.Limit)
                .InclusiveBetween(0, 50);
        }
    }
}