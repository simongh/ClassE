namespace ClassE.Venue
{
    public abstract record VenueModel : VenueBaseModel
    {
        public string? Address { get; init; }
    }
}