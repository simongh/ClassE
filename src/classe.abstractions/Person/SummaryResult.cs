using AutoMapper;

namespace ClassE.Person
{
    public record SummaryResult
    {
        public int Id { get; init; }

        public string FirstName { get; init; } = null!;

        public string LastName { get; init; } = null!;

        public string? Email { get; init; }

        public string? Phone { get; init; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Entities.Person, SummaryResult>();
            }
        }
    }
}