using AutoMapper;

namespace ClassE.Person
{
    public record SessionResult
    {
        public DateOnly Date { get; init; }

        public int StartTime { get; init; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Entities.Session, SessionResult>()
                    .ForMember(m => m.StartTime, config => config.MapFrom(m => m.Class.StartTime));
            }
        }
    }
}