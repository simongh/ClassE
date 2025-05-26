using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Classes
{
    public record UpdateCommand : IRequest<int>
    {
        public int? Id { get; set; }

        public DayOfWeek DayOfWeek { get; init; }
        public DateTime StartDate { get; init; }

        public DateTime EndDate { get; init; }

        public int StartTime { get; init; }

        public int Duration { get; init; }

        public int VenueId { get; init; }

        public float Cost { get; init; }
    }

    internal class UpdateCommandHandler(Data.IDataContext dataContext) : IRequestHandler<UpdateCommand, int>
    {
        private readonly Data.IDataContext _dataContext = dataContext;

        public async Task<int> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            Entities.Class theClass;

            var found = await _dataContext.Venues.AnyAsync(v => v.Id == request.VenueId);
            if (!found)
            {
                throw new ValidationException([new ValidationFailure(nameof(request.VenueId), $"Venue '{request.VenueId}' was not found")]);
            }

            if (request.Id == null)
            {
                theClass = new();
                _dataContext.Class.Add(theClass);
            }
            else
            {
                theClass = (await _dataContext.Class
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken))
                    ?? throw new NotFoundException();
            }

            theClass.StartDate = request.StartDate;
            theClass.EndDate = request.EndDate;
            theClass.Cost = request.Cost;
            theClass.StartTime = (byte)request.StartTime;
            theClass.Duration = (byte)request.Duration;
            theClass.VenueId = request.VenueId;

            await _dataContext.SaveChangesAsync(cancellationToken);

            return theClass.Id;
        }
    }
}