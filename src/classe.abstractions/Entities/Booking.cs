namespace ClassE.Entities
{
    public class Booking
    {
        public int Id { get; init; }

        public int PersonId { get; set; }

        public int ClassId { get; set; }

        public byte[]? RowVersion { get; init; }

        public Person Person { get; set; } = null!;

        public Class Class { get; set; } = null!;

        public bool WaitingList { get; set; }
    }
}