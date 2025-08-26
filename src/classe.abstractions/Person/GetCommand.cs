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
            var result = (await _dataContext.People
                .Where(p => p.Id == request.Id)
                .ProjectTo<PersonResult>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken))
                ?? throw new NotFoundException();

            return result with
            {
                Payments = await _dataContext.Payments.Where(p => p.PersonId == request.Id)
                    .OrderByDescending(p => p.Created)
                    .Take(5)
                    .ProjectTo<Models.PaymentModel>(_mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken),
                Sessions = await _dataContext.Sessions.Where(s => s.Attendees.Any(a => a.Id == request.Id))
                    .OrderByDescending(s => s.Date)
                    .Take(5)
                    .ProjectTo<SessionResult>(_mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken),
                Bookings = await _dataContext.Bookings.Where(b => b.PersonId == request.Id && !b.WaitingList)
                    .OrderBy(b => b.Class.DayOfWeek).ThenBy(b => b.Class.StartTime)
                    .ProjectTo<BookingResult>(_mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken),
                WaitingList = await _dataContext.Bookings.Where(b => b.PersonId == request.Id && b.WaitingList)
                    .OrderBy(b => b.Class.DayOfWeek).ThenBy(b => b.Class.StartTime)
                    .ProjectTo<BookingResult>(_mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken),
            };
        }
    }
}