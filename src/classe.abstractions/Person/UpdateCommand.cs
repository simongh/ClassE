using ClassE.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ClassE.Person
{
    public record UpdateCommand : IRequest<int>
    {
        public int? Id { get; set; }

        public string FirstName { get; init; } = null!;

        public string LastName { get; init; } = null!;

        public string? Email { get; init; }

        public string? Phone { get; init; }

        public string? Address { get; init; }

        public DateTime DateOfBirth { get; init; }

        public Gender Gender { get; init; }

        public string? Occupation { get; init; }

        public string? EmergencyContact { get; init; }

        public string? EmergencyContactNumber { get; init; }

        public string? Notes { get; init; }

        public DateTime? ConsentDate { get; init; }

        public JoiningQuestionsModel? JoiningQuestions { get; init; }
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
            person.Address = request.Address;
            person.DateOfBirth = request.DateOfBirth;
            person.Gender = request.Gender;
            person.EmergencyContact = request.EmergencyContact;
            person.EmergencyContactNumber = request.EmergencyContactNumber;
            person.Occupation = request.Occupation;
            person.Notes = request.Notes;
            person.ConsentDate = request.ConsentDate;

            if (request.JoiningQuestions != null)
            {
                person.JoiningNotes = JsonSerializer.Serialize(request.JoiningQuestions);
            }

            await _dataContext.SaveChangesAsync(cancellationToken);

            return person.Id;
        }
    }
}