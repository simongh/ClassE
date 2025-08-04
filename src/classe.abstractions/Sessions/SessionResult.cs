using AutoMapper;

namespace ClassE.Sessions
{
    public record SessionResult
    {
        public DateOnly Date { get; init; }

        public ClassResult Class { get; init; } = null!;

        public IEnumerable<Models.LookUpResult> Attendees { get; init; } = null!;

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Entities.Session, SessionResult>();
            }
        }
    }
}