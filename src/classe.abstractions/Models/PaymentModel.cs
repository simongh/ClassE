namespace ClassE.Models
{
    public record PaymentModel : Types.IMapFrom<Entities.Payment>
    {
        public int? Id { get; init; }

        public DateTime Created { get; init; }

        public float Amount { get; init; }
    }
}