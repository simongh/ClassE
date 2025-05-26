namespace ClassE.Classes
{
    public record VenueResult : Types.IMapFrom<Entities.Venue>
    {
        public int Id { get; init; }

        public string Name { get; init; } = null!;
    }
}