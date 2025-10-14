using AutoMapper;

namespace ClassE.Venue
{
    public record SummaryResult : VenueBaseModel
    {
        public int Id { get; init; }

        public bool Deletable { get; init; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Entities.Venue, SummaryResult>()
                    .ForMember(m => m.Deletable, config => config.MapFrom(m => m.classes.Count == 0));
            }
        }
    }
}