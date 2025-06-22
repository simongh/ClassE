using AutoMapper;
using ClassE.Models;

namespace ClassE.Classes
{
    public record ClassResult : Types.IMapFrom<Entities.Class>
    {
        public DayOfWeek DayOfWeek { get; init; }

        public string StartTime { get; init; } = null!;

        public int Duration { get; init; }

        public bool IsActive { get; init; }

        public VenueResult Venue { get; init; } = null!;

        public IEnumerable<IdNameResult> Bookings { get; init; } = null!;

        public IEnumerable<IdNameResult> WaitingList { get; init; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entities.Class, ClassResult>()
                .ForMember(p => p.Bookings, config => config.MapFrom(c => c.Bookings.Where(b => !b.WaitingList)))
                .ForMember(p => p.WaitingList, config => config.MapFrom(c => c.Bookings.Where(b => b.WaitingList)));
        }
    }
}