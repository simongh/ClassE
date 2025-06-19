namespace ClassE.Entities
{
    public class Class
    {
        public int Id { get; init; }

        public DayOfWeek DayOfWeek { get; set; }

        public bool IsActive { get; set; }

        public string StartTime { get; set; } = null!;

        public byte Duration { get; set; }

        public byte[]? RowVersion { get; init; }

        public int VenueId { get; set; }

        public Venue Venue { get; set; } = null!;
        public ICollection<Session> Sessions { get; set; } = [];

        public ICollection<Booking> Bookings { get; set; } = [];
    }
}