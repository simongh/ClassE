using AutoMapper;

namespace ClassE.Sessions
{
    public record AttendeeResult
    {
        public int Id { get; init; }

        public string Name { get; init; } = null!;

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Entities.Person, AttendeeResult>()
                    .ForMember(m => m.Name, config => config.MapFrom(m => m.FirstName + " " + m.LastName));
            }
        }
    }
}