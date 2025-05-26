using ClassE.Types;

namespace ClassE.Person
{
    public record PaymentResult : IMapFrom<Entities.Payment>
    {
        public DateOnly Created { get; init; }

        public float Amount { get; init; }

        public int Classes { get; init; }
    }
}