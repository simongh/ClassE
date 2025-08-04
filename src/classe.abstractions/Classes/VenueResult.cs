using AutoMapper;

namespace ClassE.Classes
{
    public record VenueResult
    {
        public int Id { get; init; }

        public string Name { get; init; } = null!;

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Entities.Venue, VenueResult>();
            }
        }
    }
}