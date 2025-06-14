using FluentValidation;

namespace ClassE.Payments
{
    internal class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(m => m.Credits)
                .GreaterThanOrEqualTo(0);
        }
    }
}