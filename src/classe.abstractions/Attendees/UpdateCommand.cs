using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Attendees
{
    public record UpdateCommand : IRequest
    {
        public int Session { get; init; }

        public IEnumerable<int> People { get; init; } = null!;
    }

    internal class UpdateCommandHandler(
        Data.IDataContext dataContext)
        : IRequestHandler<UpdateCommand>
    {
        private readonly Data.IDataContext _dataContext = dataContext;

        public async Task Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var session = (await _dataContext.Sessions
                .Include(s => s.Attendees)
                .FirstOrDefaultAsync(s => s.Id == request.Session, cancellationToken))
                ?? throw new NotFoundException();

            var found = await _dataContext.People
                .Where(p => request.People.Contains(p.Id))
                .CountAsync(cancellationToken);

            if (found != request.People.Count())
                throw new ValidationException([new ValidationFailure(nameof(request.People), $"{request.People.Count() - found} people were not found")])

            var toAction = session.Attendees
                .Where(a => !request.People.Contains(a.Id));

            foreach (var item in toAction)
            {
                item.ClassBalance++;

                item.Sessions.Remove(session);
            }

            toAction = await _dataContext.People
                .Where(p => request.People.Contains(p.Id) && !session.Attendees.Any(a => a.Id == p.Id))
                .ToArrayAsync(cancellationToken);

            foreach (var item in toAction)
            {
                item.ClassBalance--;
                item.Sessions.Add(session);
            }

            await _dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}