using AutoMapper;
using ClassE.Types;

namespace ClassE.Person
{
    public record SessionResult : IMapFrom<Entities.Session>
    {
        public DateOnly Date { get; init; }

        public int StartTime { get; init; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entities.Session, SessionResult>()
                .ForMember(m => m.StartTime, config => config.MapFrom(m => m.Class.StartTime));
        }
    }
}