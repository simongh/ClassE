namespace ClassE.Venue
{
    public record SummaryResult : Types.IMapFrom<Entities.Venue>
    {
        public int Id { get; init; }

        public string Name { get; init; } = null!;

        public string? Email { get; init; }

        public string? Phone { get; init; }
    }
}