using FluentValidation;

namespace ClassE.Classes
{
    internal class ClassesQueryValidator : AbstractValidator<ClassesQuery>
    {
        public ClassesQueryValidator(Validators.QueryValidator queryValidator)
        {
            Include(queryValidator);
        }
    }
}