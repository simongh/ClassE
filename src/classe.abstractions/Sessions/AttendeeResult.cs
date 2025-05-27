using AutoMapper;

namespace ClassE.Sessions
{
    public record AttendeeResult : Types.IMapFrom<Entities.Person>
    {
        public int Id { get; init; }

        public string Name { get; init; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entities.Person, AttendeeResult>()
                .ForMember(m => m.Name, config => config.MapFrom(m => m.FirstName + " " + m.LastName));
        }
    }
}