using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClassE.Types;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Person
{
    public record PersonQuery : Types.BaseQuery, IRequest<Types.SearchResult<SummaryResult>>
    {
    }

    internal class PersonQueryHandler(
        Data.IDataContext dataContext,
        IMapper mapper)
        : IRequestHandler<PersonQuery, Types.SearchResult<SummaryResult>>
    {
        private readonly Data.IDataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public async Task<SearchResult<SummaryResult>> Handle(PersonQuery request, CancellationToken cancellationToken)
        {
            var query = _dataContext.People;

            return new()
            {
                Total = await query.CountAsync(cancellationToken),
                Results = await query
                    .OrderBy(p => p.FirstName)
                    .ThenBy(p => p.LastName)
                    .Skip(request.Offset)
                    .Take(request.Limit)
                    .ProjectTo<SummaryResult>(_mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken),
            };
        }
    }
}