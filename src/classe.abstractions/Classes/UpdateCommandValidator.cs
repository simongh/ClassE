using FluentValidation;

namespace ClassE.Classes
{
    internal class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(m => m.DayOfWeek)
                .IsInEnum();

            RuleFor(m => m.StartTime)
                .Matches(@"^(?:[01]\d|2[0-3]):[0-5]\d")
                .NotEmpty();

            RuleFor(m => m.Duration)
                .InclusiveBetween(1, 120);
        }
    }
}