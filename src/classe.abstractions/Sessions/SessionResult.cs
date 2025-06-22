namespace ClassE.Sessions
{
    public record SessionResult : Types.IMapFrom<Entities.Session>
    {
        public DateOnly Date { get; init; }

        public ClassResult Class { get; init; } = null!;

        public IEnumerable<Models.IdNameResult> Attendees { get; init; } = null!;
    }
}