using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClassE.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Classes
{
    public record ClassesQuery : Types.BaseQuery<SummaryResult>
    {
        public bool All { get; init; }
    }

    internal class ClassesQueryHandler(
        Data.IDataContext dataContext,
        IMapper mapper)
        : IRequestHandler<ClassesQuery, Types.SearchResult<SummaryResult>>
    {
        private readonly IDataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public async Task<Types.SearchResult<SummaryResult>> Handle(ClassesQuery request, CancellationToken cancellationToken)
        {
            var query = _dataContext.Classes.AsQueryable();

            if (!request.All)
                query = query.Where(c => c.IsActive);

            return new()
            {
                Total = await query.CountAsync(cancellationToken),
                Results = await query
                    .OrderBy(s => s.DayOfWeek)
                    .ThenBy(s => s.StartTime)
                    .Skip(request.Offset)
                    .Take(request.Limit)
                    .ProjectTo<SummaryResult>(_mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken),
            };
        }
    }
}