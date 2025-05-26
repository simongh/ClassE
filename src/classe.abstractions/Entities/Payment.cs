namespace ClassE.Entities
{
    public class Payment
    {
        public int Id { get; init; }

        public DateTime Created { get; set; }

        public float Amount { get; set; }

        public int Classes { get; set; }
        public byte[]? RowVersion { get; init; }
    }
}