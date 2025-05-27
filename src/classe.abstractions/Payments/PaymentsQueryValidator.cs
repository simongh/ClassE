using FluentValidation;

namespace ClassE.Payments
{
    internal class PaymentsQueryValidator : AbstractValidator<PaymentsQuery>
    {
        public PaymentsQueryValidator(Validators.QueryValidator queryValidator)
        {
            Include(queryValidator);
        }
    }
}