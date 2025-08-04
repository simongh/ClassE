using AutoMapper;

namespace ClassE.Venue
{
    public record SummaryResult
    {
        public int Id { get; init; }

        public string Name { get; init; } = null!;

        public string? Email { get; init; }

        public string? Phone { get; init; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Entities.Venue, SummaryResult>();
            }
        }
    }
}