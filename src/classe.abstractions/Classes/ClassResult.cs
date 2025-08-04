using AutoMapper;
using ClassE.Models;

namespace ClassE.Classes
{
    public record ClassResult
    {
        public DayOfWeek DayOfWeek { get; init; }

        public string StartTime { get; init; } = null!;

        public int Duration { get; init; }

        public bool IsActive { get; init; }

        public VenueResult Venue { get; init; } = null!;

        public IEnumerable<LookUpResult> Bookings { get; init; } = null!;

        public IEnumerable<LookUpResult> WaitingList { get; init; } = null!;

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Entities.Class, ClassResult>()
                    .ForMember(p => p.Bookings, config => config.MapFrom(c => c.Bookings.Where(b => !b.WaitingList)))
                    .ForMember(p => p.WaitingList, config => config.MapFrom(c => c.Bookings.Where(b => b.WaitingList)));
            }
        }
    }
}