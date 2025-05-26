using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Venue
{
    public record GetCommand : IRequest<VenueResult>
    {
        public int Id { get; init; }
    }

    internal class GetCommandHandler(
        Data.IDataContext dataContext,
        IMapper mapper)
        : IRequestHandler<GetCommand, VenueResult>
    {
        private readonly Data.IDataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public async Task<VenueResult> Handle(GetCommand request, CancellationToken cancellationToken)
        {
            return (await _dataContext.Venues
                .Where(v => v.Id == request.Id)
                .ProjectTo<VenueResult>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken))
                ?? throw new NotFoundException();
        }
    }
}