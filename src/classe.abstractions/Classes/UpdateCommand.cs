using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Classes
{
    public record UpdateCommand : IRequest<int>
    {
        public int? Id { get; init; }

        public DayOfWeek DayOfWeek { get; init; }

        public bool IsActive { get; init; }

        public string StartTime { get; init; } = null!;

        public int Duration { get; init; }

        public int Venue { get; init; }
    }

    internal class UpdateCommandHandler(Data.IDataContext dataContext) : IRequestHandler<UpdateCommand, int>
    {
        private readonly Data.IDataContext _dataContext = dataContext;

        public async Task<int> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            Entities.Class theClass;

            var found = await _dataContext.Venues.AnyAsync(v => v.Id == request.Venue);
            if (!found)
            {
                throw new ValidationException([new ValidationFailure(nameof(request.Venue), $"Venue '{request.Venue}' was not found")]);
            }

            if (request.Id == null)
            {
                theClass = new();
                _dataContext.Classes.Add(theClass);
            }
            else
            {
                theClass = (await _dataContext.Classes
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken))
                    ?? throw new NotFoundException();
            }

            theClass.DayOfWeek = request.DayOfWeek;
            theClass.IsActive = request.IsActive;
            theClass.StartTime = request.StartTime;
            theClass.Duration = (byte)request.Duration;
            theClass.VenueId = request.Venue;

            await _dataContext.SaveChangesAsync(cancellationToken);

            return theClass.Id;
        }
    }
}