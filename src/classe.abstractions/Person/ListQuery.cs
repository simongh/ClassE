using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Person
{
    public record ListQuery : IRequest<IEnumerable<Models.LookUpResult>>
    {
    }

    internal class ListQueryHandler(
        Data.IDataContext dataContext,
        IMapper mapper) : IRequestHandler<ListQuery, IEnumerable<Models.LookUpResult>>
    {
        private readonly Data.IDataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<Models.LookUpResult>> Handle(ListQuery request, CancellationToken cancellationToken)
        {
            return await _dataContext.People
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.LastName)
                .ProjectTo<Models.LookUpResult>(_mapper.ConfigurationProvider)
                .ToArrayAsync();
        }
    }
}