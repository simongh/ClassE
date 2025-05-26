namespace ClassE.Venue
{
    public record VenueResult : Types.IMapFrom<Entities.Venue>
    {
        public string Name { get; init; } = null!;

        public string? Email { get; init; }

        public string? Phone { get; init; }
        public string? Address { get; init; }
    }
}