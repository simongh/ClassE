using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Sessions
{
    public record GetCommand : IRequest<SessionResult>
    {
        public int Id { get; set; }
    }

    internal class GetCommandHandler(
        Data.IDataContext dataContext,
        IMapper mapper)
        : IRequestHandler<GetCommand, SessionResult>
    {
        private readonly Data.IDataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public async Task<SessionResult> Handle(GetCommand request, CancellationToken cancellationToken)
        {
            return (await _dataContext.Sessions
                .Where(s => s.Id == request.Id)
                .ProjectTo<SessionResult>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken))
                ?? throw new NotFoundException();
        }
    }
}