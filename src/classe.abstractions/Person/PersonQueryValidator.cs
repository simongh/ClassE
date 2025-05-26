using FluentValidation;

namespace ClassE.Person
{
    internal class PersonQueryValidator : AbstractValidator<PersonQuery>
    {
        public PersonQueryValidator(Validators.QueryValidator queryValidator)
        {
            Include(queryValidator);
        }
    }
}