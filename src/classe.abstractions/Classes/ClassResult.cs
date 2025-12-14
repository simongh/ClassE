using AutoMapper;

namespace ClassE.Classes
{
    public record ClassResult
    {
        public DayOfWeek DayOfWeek { get; init; }

        public string StartTime { get; init; } = null!;

        public byte Duration { get; init; }

        public bool IsActive { get; init; }

        public float Cost { get; init; }

        public Models.LookUpResult Venue { get; init; } = null!;

        public IEnumerable<Models.LookUpResult> Bookings { get; init; } = [];

        public IEnumerable<Models.LookUpResult> WaitingList { get; init; } = [];

        public IEnumerable<SessionResult> Sessions { get; init; } = [];

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Entities.Class, ClassResult>()
                    .ForMember(p => p.Bookings, config => config.Ignore())
                    .ForMember(p => p.WaitingList, config => config.Ignore())
                    .ForMember(p => p.Sessions, config => config.Ignore());
            }
        }
    }
}