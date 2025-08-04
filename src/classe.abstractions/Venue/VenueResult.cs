using AutoMapper;

namespace ClassE.Venue
{
    public record VenueResult
    {
        public string Name { get; init; } = null!;

        public string? Email { get; init; }

        public string? Phone { get; init; }
        public string? Address { get; init; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Entities.Venue, VenueResult>();
            }
        }
    }
}