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
                person.Credits += request.Credits;
            }
            else
            {
                payment = (await _dataContext.Payments
                    .FirstOrDefaultAsync(p => p.Id == request.Id.Value))
                    ?? throw new NotFoundException();

                person.Credits += request.Credits - payment.Credits;
            }

            payment.Created = request.Created;
            payment.Amount = request.Amount;
            payment.Credits = request.Credits;

            await _dataContext.SaveChangesAsync(cancellationToken);

            return payment.Id;
        }
    }
}