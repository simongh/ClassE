using FluentValidation;

namespace ClassE.Classes
{
    internal class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(m => m.StartDate)
                .LessThan(m => m.EndDate);

            RuleFor(m => m.EndDate)
                .GreaterThan(m => m.StartDate);

            RuleFor(m => m.StartTime)
                .InclusiveBetween(0, 23);

            RuleFor(m => m.Duration)
                .InclusiveBetween(1, 120);

            RuleFor(m => m.Cost)
                .GreaterThanOrEqualTo(0);

            RuleFor(m => m.DayOfWeek)
                .IsInEnum();
        }
    }
}