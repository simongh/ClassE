using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Person
{
    public record UpdateCommand : IRequest<int>
    {
        public int? Id { get; set; }

        public string FirstName { get; init; } = null!;

        public string LastName { get; init; } = null!;

        public string? Email { get; init; }

        public string? Phone { get; init; }
    }

    internal class UpdateCommandHandler(Data.IDataContext dataContext) : IRequestHandler<UpdateCommand, int>
    {
        private readonly Data.IDataContext _dataContext = dataContext;

        public async Task<int> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            Entities.Person person;

            if (request.Id == null)
            {
                person = new();
                _dataContext.People.Add(person);
            }
            else
            {
                person = (await _dataContext.People.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken))
                    ?? throw new NotFoundException();
            }

            person.FirstName = request.FirstName;
            person.LastName = request.LastName;
            person.Email = request.Email;
            person.Phone = request.Phone;

            await _dataContext.SaveChangesAsync(cancellationToken);

            return person.Id;
        }
    }
}