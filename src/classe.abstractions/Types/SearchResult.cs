namespace ClassE.Types
{
    public record SearchResult<T>
    {
        public IEnumerable<T> Results { get; init; } = null!;

        public int Total { get; init; }
    }
}