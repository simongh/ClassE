using FluentValidation;

namespace ClassE.Payments
{
    internal class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(m => m.Amount)
                .GreaterThanOrEqualTo(0);
        }
    }
}