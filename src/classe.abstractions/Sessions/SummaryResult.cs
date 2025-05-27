using AutoMapper;

namespace ClassE.Sessions
{
    public record SessionModel : Types.IMapFrom<Entities.Session>
    {
        public int Id { get; init; }

        public DateTime Date { get; init; }

        public int Attending { get; init; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entities.Session, SessionModel>()
                .ForMember(m => m.Attending, config => config.MapFrom(m => m.Attendees.Count));
        }
    }
}