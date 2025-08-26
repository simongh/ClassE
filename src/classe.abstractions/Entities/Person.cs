using System.Text.Json.Serialization;

namespace ClassE.Entities
{
    public class Person
    {
        public int Id { get; init; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public float Balance { get; set; }

        public string? Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string? Occupation { get; set; }

        public string? EmergencyContact { get; set; }

        public string? EmergencyContactNumber { get; set; }

        public string? JoiningNotes { get; set; }

        public string? Notes { get; set; }

        public DateTime? ConsentDate { get; set; }

        public byte[]? RowVersion { get; init; }
        public ICollection<Session> Sessions { get; set; } = [];

        public ICollection<Booking> Bookings { get; set; } = [];

        public ICollection<Payment> Payments { get; set; } = [];
    }

    [JsonConverter(typeof(JsonStringEnumConverter<Gender>))]
    public enum Gender
    {
        Unknown,
        Male,
        Female
    }

    /*
     * joining notes
     * --------------
     * regular exercise
     * what other exercise
     * goals
     * existing medical conditions
     * joint injuries
     * additional needs
     * doctor recommendation
     * pain on physical activity
     * chest pain
     * dizziness
     * doctor prescribed drugs
     * bone or join problems
     * epilepsy
     * diabetes
     * asthma
     * any reason not to do physical activity
     * discussed above with doctor
     * additional info
     */
}