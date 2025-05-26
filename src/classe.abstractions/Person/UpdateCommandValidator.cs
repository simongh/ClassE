using FluentValidation;

namespace ClassE.Person
{
    internal class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(m => m.FirstName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(m => m.LastName)
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