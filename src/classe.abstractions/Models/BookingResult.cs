using AutoMapper;

namespace ClassE.Models
{
    public record BookingResult : Types.IMapFrom<Entities.Booking>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entities.Booking, BookingResult>()
                .ForMember(p => p.Name, config => config.MapFrom(b => b.Person.FirstName + " " + b.Person.LastName));
        }
    }
}