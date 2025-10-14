namespace ClassE.Person
{
    public abstract record PersonBaseModel
    {
        public string FirstName { get; init; } = null!;

        public string LastName { get; init; } = null!;

        public string? Email { get; init; }

        public string? Phone { get; init; }
    }
}