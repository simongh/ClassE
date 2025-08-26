using AutoMapper;

namespace ClassE.Person
{
    public record SessionResult
    {
        public DateTime Date { get; init; }

        public string StartTime { get; init; } = null!;

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