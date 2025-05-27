using FluentValidation;

namespace ClassE.Attendees
{
    internal class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(m => m.People)
                .NotNull();

            RuleFor(m => m.People)
                .Must(m => m.Count() != m.Distinct().Count())
                .WithMessage("People entries must be unique");
        }
    }
}