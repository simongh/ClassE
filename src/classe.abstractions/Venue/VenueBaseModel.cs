namespace ClassE.Venue
{
    public abstract record VenueBaseModel
    {
        public string Name { get; init; } = null!;

        public string? Email { get; init; }

        public string? Phone { get; init; }
    }
}