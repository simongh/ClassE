namespace ClassE.Sessions
{
    public record SessionResult : Types.IMapFrom<Entities.Session>
    {
        public DateOnly Date { get; init; }

        public ClassResult Class { get; init; } = null!;

        public IEnumerable<Models.BookingResult> Attendees { get; init; } = null!;
    }
}