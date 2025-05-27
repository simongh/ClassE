using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Payments
{
    public record UpdateCommand : Models.PaymentModel, IRequest<int>
    {
        public int Person { get; init; }
    }

    internal class UpdateCommandHandler(Data.IDataContext dataContext) : IRequestHandler<UpdateCommand, int>
    {
        private readonly Data.IDataContext _dataContext = dataContext;

        public async Task<int> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var person = (await _dataContext.People
                .FirstOrDefaultAsync(p => p.Id == request.Person))
                ?? throw new NotFoundException($"Person {request.Person} does not exist");

            Entities.Payment payment;
            if (request.Id == null)
            {
                payment = new()
                {
                    PersonId = request.Person
                };
                _dataContext.Payments.Add(payment);
                person.ClassBalance += request.Classes;
            }
            else
            {
                payment = (await _dataContext.Payments
                    .FirstOrDefaultAsync(p => p.Id == request.Id.Value))
                    ?? throw new NotFoundException();

                person.ClassBalance += request.Classes - payment.Classes;
            }

            payment.Created = request.Created;
            payment.Amount = request.Amount;
            payment.Classes = request.Classes;

            await _dataContext.SaveChangesAsync(cancellationToken);

            return payment.Id;
        }
    }
}