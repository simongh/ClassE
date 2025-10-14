using FluentValidation;

namespace ClassE
{
    internal static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, string?> Phone<T>(this IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder
                .MaximumLength(16)
                .Matches(@"^(?:(?:\(0\d+\))|0\d+) ?\d. ?\d*$")
                .WithMessage("Invalid phone number");
        }
    }
}