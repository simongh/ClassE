namespace ClassE.Person
{
    public abstract record PersonModel : PersonBaseModel
    {
        public string? Address { get; init; }

        public DateTime DateOfBirth { get; init; }

        public Entities.Gender Gender { get; init; }

        public string? Occupation { get; set; }

        public string? EmergencyContact { get; set; }

        public string? EmergencyContactNumber { get; set; }

        public string? Notes { get; set; }

        public DateTime? ConsentDate { get; set; }
    }
}