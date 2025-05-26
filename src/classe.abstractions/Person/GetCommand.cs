using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Person
{
    public record GetCommand : IRequest<PersonResult>
    {
        public int Id { get; init; }
    }

    internal class GetCommandHandler(
        Data.IDataContext dataContext,
        IMapper mapper) : IRequestHandler<GetCommand, PersonResult>
    {
        private readonly Data.IDataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public async Task<PersonResult> Handle(GetCommand request, CancellationToken cancellationToken)
        {
            return (await _dataContext.People
                .Where(p => p.Id == request.Id)
                .ProjectTo<PersonResult>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken))
                ?? throw new NotFoundException();
        }
    }
}