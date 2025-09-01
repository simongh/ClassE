namespace ClassE.Entities
{
    public class User
    {
        public int Id { get; init; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool IsAdmin { get; set; }
    }
}