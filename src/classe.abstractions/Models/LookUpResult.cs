using AutoMapper;

namespace ClassE.Models
{
    public record LookUpResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Entities.Booking, LookUpResult>()
                    .ForMember(p => p.Name, config => config.MapFrom(b => b.Person.FirstName + " " + b.Person.LastName));

                CreateMap<Entities.Person, LookUpResult>()
                    .ForMember(p => p.Name, config => config.MapFrom(b => b.FirstName + " " + b.LastName));
            }
        }
    }
}