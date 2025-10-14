using FluentValidation;

namespace ClassE.Payments
{
    internal class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator()
        {
        }
    }
}