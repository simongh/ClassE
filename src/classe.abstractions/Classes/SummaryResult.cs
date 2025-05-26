using AutoMapper;

namespace ClassE.Classes
{
    public record SummaryResult : Types.IMapFrom<Entities.Class>
    {
        public int Id { get; init; }

        public DayOfWeek DayOfWeek { get; init; }
        public DateTime StartDate { get; init; }

        public DateTime EndDate { get; init; }

        public int StartTime { get; init; }

        public int Duration { get; init; }

        public VenueResult Venue { get; init; } = null!;

        public int Booked { get; init; }

        public int Waiting { get; init; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entities.Class, SummaryResult>()
                .ForMember(p => p.Booked, config => config.MapFrom(p => p.Bookings.Where(b => !b.WaitingList).Count()))
                .ForMember(p => p.Waiting, config => config.MapFrom(p => p.Bookings.Where(b => b.WaitingList).Count()))
                ;
        }
    }
}