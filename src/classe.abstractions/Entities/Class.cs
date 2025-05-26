namespace ClassE.Entities
{
    public class Class
    {
        public int Id { get; init; }

        public DayOfWeek DayOfWeek { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public byte StartTime { get; set; }

        public byte Duration { get; set; }

        public float Cost { get; set; }

        public byte[]? RowVersion { get; init; }

        public int VenueId { get; set; }

        public Venue Venue { get; set; } = null!;
        public ICollection<Session> Sessions { get; set; } = [];

        public ICollection<Booking> Bookings { get; set; } = [];
    }
}