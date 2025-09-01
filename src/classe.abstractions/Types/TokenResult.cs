namespace ClassE.Types
{
    public record TokenResult
    {
        public string? Token { get; init; }

        public DateTimeOffset Expires { get; init; }

        public bool Success { get; init; }

        public bool IsAdmin { get; init; }
    }
}