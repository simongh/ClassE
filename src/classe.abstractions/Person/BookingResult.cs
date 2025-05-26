using AutoMapper;
using ClassE.Types;

namespace ClassE.Person
{
    public record BookingResult : IMapFrom<Entities.Booking>
    {
        public DayOfWeek Day { get; init; }

        public int StartTime { get; init; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entities.Booking, BookingResult>()
                .ForMember(p => p.Day, config => config.MapFrom(b => b.Class.DayOfWeek))
                .ForMember(p => p.StartTime, config => config.MapFrom(b => b.Class.StartTime));
        }
    }
}