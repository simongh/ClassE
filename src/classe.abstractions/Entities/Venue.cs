namespace ClassE.Entities
{
    public class Venue
    {
        public int Id { get; init; }

        public string Name { get; set; } = null!;

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }
        public byte[]? RowVersion { get; init; }

        public ICollection<Class> classes { get; set; } = [];
    }
}