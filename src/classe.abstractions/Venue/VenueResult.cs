using AutoMapper;

namespace ClassE.Venue
{
    public record VenueResult : VenueModel
    {
        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Entities.Venue, VenueResult>();
            }
        }
    }
}