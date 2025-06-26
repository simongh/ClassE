namespace ClassE.Entities
{
    public class Person
    {
        public int Id { get; init; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public float Balance { get; set; }

        public byte[]? RowVersion { get; init; }
        public ICollection<Session> Sessions { get; set; } = [];

        public ICollection<Booking> Bookings { get; set; } = [];

        public ICollection<Payment> Payments { get; set; } = [];
    }
}