using FluentValidation;

namespace ClassE.Venue
{
    internal class UpdateCommandValidator : AbstractValidator<UpdateVenueCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(m => m.Email)
                .EmailAddress()
                .MaximumLength(200);

            RuleFor(m => m.Phone)
                .Phone();
        }
    }
}