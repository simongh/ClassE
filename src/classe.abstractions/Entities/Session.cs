namespace ClassE.Entities
{
    public class Session
    {
        public int Id { get; init; }

        public DateTime Date { get; set; }

        public int ClassId { get; set; }

        public byte[]? RowVersion { get; init; }
        public virtual Class Class { get; set; } = null!;

        public ICollection<Person> Attendees { get; set; } = [];
    }
}