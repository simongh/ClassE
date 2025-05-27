using MediatR;

namespace ClassE.Types
{
    public abstract record BaseQuery
    {
        public int Offset { get; init; }

        public int Limit { get; init; } = 50;
    }

    public abstract record BaseQuery<TResult> : BaseQuery, IRequest<SearchResult<TResult>>
    { }
}