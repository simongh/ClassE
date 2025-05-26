using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Venue
{
    public record UpdateVenueCommand : IRequest<int>
    {
        public int? Id { get; set; }

        public string Name { get; init; } = null!;

        public string? Email { get; init; }
        public string? Phone { get; init; }
        public string? Address { get; init; }
    }

    internal class UpdateVenueCommandHandler(
        Data.IDataContext dataContext)
        : IRequestHandler<UpdateVenueCommand, int>
    {
        private readonly Data.IDataContext _dataContext = dataContext;

        public async Task<int> Handle(UpdateVenueCommand request, CancellationToken cancellationToken)
        {
            Entities.Venue venue;

            if (request.Id == null)
            {
                venue = new();
                _dataContext.Venues.Add(venue);
            }
            else
            {
                venue = (await _dataContext.Venues
                    .FirstOrDefaultAsync(v => v.Id == request.Id.Value, cancellationToken))
                    ?? throw new NotFoundException();
            }

            venue.Name = request.Name;
            venue.Email = request.Email;
            venue.Phone = request.Phone;
            venue.Address = request.Address;

            await _dataContext.SaveChangesAsync(cancellationToken);

            return venue.Id;
        }
    }
}