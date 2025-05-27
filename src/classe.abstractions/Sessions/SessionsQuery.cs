using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClassE.Classes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Sessions
{
    public record SessionsQuery : Types.BaseQuery<SummaryResult>
    {
        public DateTime? StartDate { get; init; }

        public DateTime? EndDate { get; init; }

        public int? Class { get; init; }

        public int? Person { get; init; }
    }

    public class SessionsQueryHandler(
        Data.IDataContext dataContext,
        IMapper mapper) : IRequestHandler<SessionsQuery, Types.SearchResult<SummaryResult>>
    {
        private readonly Data.IDataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public async Task<Types.SearchResult<SummaryResult>> Handle(SessionsQuery request, CancellationToken cancellationToken)
        {
            var query = _dataContext.Sessions.AsQueryable();

            if (request.Class.HasValue)
                query = query.Where(s => s.ClassId == request.Class);

            if (request.Person.HasValue)
                query = query.Where(s => s.Attendees.Any(a => a.Id == request.Person));

            if (request.StartDate.HasValue)
                query = query.Where(s => s.Date >= request.StartDate.Value);

            if (request.EndDate.HasValue)
                query = query.Where(s => s.Date <= request.EndDate.Value);

            return new()
            {
                Total = await query.CountAsync(),
                Results = await query
                    .OrderByDescending(s => s.Date)
                    .Skip(request.Offset)
                    .Take(request.Limit)
                    .ProjectTo<SummaryResult>(_mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken),
            };
        }
    }
}