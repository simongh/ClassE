using AutoMapper;

namespace ClassE.Classes
{
    public record ClassResult : Types.IMapFrom<Entities.Class>
    {
        public DayOfWeek DayOfWeek { get; init; }
        public DateTime StartDate { get; init; }

        public DateTime EndDate { get; init; }

        public int StartTime { get; init; }

        public int Duration { get; init; }

        public VenueResult Venue { get; init; } = null!;

        public IEnumerable<BookingResult> Bookings { get; init; } = null!;

        public IEnumerable<BookingResult> WaitingList { get; init; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entities.Class, ClassResult>()
                .ForMember(p => p.Bookings, config => config.MapFrom(c => c.Bookings.Where(b => !b.WaitingList)))
                .ForMember(p => p.WaitingList, config => config.MapFrom(c => c.Bookings.Where(b => b.WaitingList)));
        }
    }
}