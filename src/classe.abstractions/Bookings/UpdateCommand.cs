using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Bookings
{
    public record UpdateCommand : IRequest<int>
    {
        public int? Id { get; init; }

        public int Class { get; init; }

        public int Person { get; init; }

        public bool WaitingList { get; init; }
    }

    internal class UpdateCommandHandler(Data.IDataContext dataContext) : IRequestHandler<UpdateCommand, int>
    {
        private readonly Data.IDataContext _dataContext = dataContext;

        public async Task<int> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            if (!await _dataContext.People.AnyAsync(p => p.Id == request.Person, cancellationToken))
                throw new NotFoundException($"Person {request.Person} was not found");

            if (!await _dataContext.Classes.AnyAsync(c => c.Id == request.Class, cancellationToken))
                throw new NotFoundException($"Class {request.Class} was not found");

            Entities.Booking booking;
            if (request.Id == null)
            {
                booking = new();
                _dataContext.Bookings.Add(booking);
            }
            else
            {
                booking = (await _dataContext.Bookings
                    .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken))
                    ?? throw new NotFoundException();
            }

            booking.PersonId = request.Person;
            booking.ClassId = request.Class;
            booking.WaitingList = request.WaitingList;

            await _dataContext.SaveChangesAsync(cancellationToken);

            return booking.Id;
        }
    }
}