namespace ClassE.Entities
{
    public class Payment
    {
        public int Id { get; init; }

        public DateTime Created { get; set; }

        public float Amount { get; set; }

        public byte[]? RowVersion { get; init; }

        public int PersonId { get; set; }

        public Person Person { get; set; } = null!;
    }
}