using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Classes
{
    public record GetCommand : IRequest<ClassResult>
    {
        public int Id { get; init; }
    }

    internal class GetCommandHandler(
        Data.IDataContext dataContext,
        IMapper mapper) : IRequestHandler<GetCommand, ClassResult>
    {
        private readonly Data.IDataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public async Task<ClassResult> Handle(GetCommand request, CancellationToken cancellationToken)
        {
            var reult = (await _dataContext.Classes
                .Where(c => c.Id == request.Id)
                .ProjectTo<ClassResult>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken))
                ?? throw new NotFoundException();

            return reult with
            {
                Bookings = await _dataContext.Bookings
                    .Where(b => b.ClassId == request.Id && !b.WaitingList)
                    .OrderBy(b => b.Person.FirstName)
                    .ThenBy(b => b.Person.LastName)
                    .ProjectTo<Models.LookUpResult>(_mapper.ConfigurationProvider)
                    .ToArrayAsync(),
                WaitingList = await _dataContext.Bookings
                    .Where(b => b.ClassId == request.Id && b.WaitingList)
                    .OrderBy(b => b.Person.FirstName)
                    .ThenBy(b => b.Person.LastName)
                    .ProjectTo<Models.LookUpResult>(_mapper.ConfigurationProvider)
                    .ToArrayAsync(),
                Sessions = await _dataContext.Sessions
                    .Where(s => s.ClassId == request.Id)
                    .OrderByDescending(s => s.Date)
                    .Take(5)
                    .ProjectTo<SessionResult>(_mapper.ConfigurationProvider)
                    .ToArrayAsync(),
            };
        }
    }
}