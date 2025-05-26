namespace ClassE.Person
{
    public record SummaryResult : Types.IMapFrom<Entities.Person>
    {
        public int Id { get; init; }

        public string FirstName { get; init; } = null!;

        public string LastName { get; init; } = null!;

        public string? Email { get; init; }

        public string? Phone { get; init; }
    }
}