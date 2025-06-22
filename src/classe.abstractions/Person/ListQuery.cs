using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Person
{
    public record ListQuery : IRequest<IEnumerable<Models.IdNameResult>>
    {
    }

    internal class ListQueryHandler(
        Data.IDataContext dataContext,
        IMapper mapper) : IRequestHandler<ListQuery, IEnumerable<Models.IdNameResult>>
    {
        private readonly Data.IDataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<Models.IdNameResult>> Handle(ListQuery request, CancellationToken cancellationToken)
        {
            return await _dataContext.People
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.LastName)
                .ProjectTo<Models.IdNameResult>(_mapper.ConfigurationProvider)
                .ToArrayAsync();
        }
    }
}