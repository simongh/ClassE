using AutoMapper;

namespace ClassE.Sessions
{
    public record SessionModel
    {
        public int Id { get; init; }

        public DateTime Date { get; init; }

        public int Attending { get; init; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Entities.Session, SessionModel>()
                    .ForMember(m => m.Attending, config => config.MapFrom(m => m.Attendees.Count));
            }
        }
    }
}