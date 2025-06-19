using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Sessions
{
    public record UpdateCommand : IRequest<int>
    {
        public int? Id { get; init; }

        public DateTime Date { get; init; }

        public int Class { get; init; }
    }

    internal class UpdateCommandHandler(
        Data.IDataContext dataContext)
        : IRequestHandler<UpdateCommand, int>
    {
        private readonly Data.IDataContext _dataContext = dataContext;

        public async Task<int> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var theClass = (await _dataContext.Classes
                .FirstOrDefaultAsync(c => c.Id == request.Class, cancellationToken))
                ?? throw new NotFoundException($"The class {request.Class} was not found");

            var found = await _dataContext.Sessions
                .Where(s => s.ClassId == request.Class && s.Date == request.Date)
                .AnyAsync();
            if (found)
                throw new ValidationException([new ValidationFailure(nameof(request.Date), "A session for this class already exists for this date")]);

            Entities.Session session;
            if (request.Id == null)
            {
                session = new()
                {
                    ClassId = request.Class,
                };
                _dataContext.Sessions.Add(session);
            }
            else
            {
                session = (await _dataContext.Sessions
                    .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken))
                    ?? throw new NotFoundException();
            }

            session.Date = request.Date;

            await _dataContext.SaveChangesAsync(cancellationToken);

            return session.Id;
        }
    }
}