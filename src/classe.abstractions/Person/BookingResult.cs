using AutoMapper;

namespace ClassE.Person
{
    public record BookingResult
    {
        public DayOfWeek Day { get; init; }

        public string StartTime { get; init; } = null!;

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Entities.Booking, BookingResult>()
                    .ForMember(p => p.Day, config => config.MapFrom(b => b.Class.DayOfWeek))
                    .ForMember(p => p.StartTime, config => config.MapFrom(b => b.Class.StartTime));
            }
        }
    }
}