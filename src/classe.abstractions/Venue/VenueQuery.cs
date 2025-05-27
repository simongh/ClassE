using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Venue
{
    public record VenueQuery : Types.BaseQuery<SummaryResult>
    {
    }

    internal class VenueQueryHandler(
        Data.IDataContext dataContext,
        IMapper mapper)
        : IRequestHandler<VenueQuery, Types.SearchResult<SummaryResult>>
    {
        private readonly Data.IDataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public async Task<Types.SearchResult<SummaryResult>> Handle(VenueQuery request, CancellationToken cancellationToken)
        {
            var query = _dataContext.Venues;

            return new()
            {
                Total = await query.CountAsync(cancellationToken),
                Results = await query
                    .OrderBy(v => v.Name)
                    .Skip(request.Offset)
                    .Take(request.Limit)
                    .ProjectTo<SummaryResult>(_mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken),
            };
        }
    }
}