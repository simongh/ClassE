using FluentValidation;

namespace ClassE.Venue
{
    internal class VenueQueryValidator : AbstractValidator<VenueQuery>
    {
        public VenueQueryValidator(Validators.QueryValidator queryValidator)
        {
            Include(queryValidator);
        }
    }
}