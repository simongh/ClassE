using AutoMapper;

namespace ClassE.Models
{
    public record IdNameResult : Types.IMapFrom<Entities.Booking>, Types.IMapFrom<Entities.Person>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entities.Booking, IdNameResult>()
                .ForMember(p => p.Name, config => config.MapFrom(b => b.Person.FirstName + " " + b.Person.LastName));

            profile.CreateMap<Entities.Person, IdNameResult>()
                .ForMember(p => p.Name, config => config.MapFrom(b => b.FirstName + " " + b.LastName));
        }
    }
}