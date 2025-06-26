using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Payments
{
    public record DeleteCommand : IRequest
    {
        public int Id { get; init; }
    }

    internal class DeleteCommandHandler(Data.IDataContext dataContext) : IRequestHandler<DeleteCommand>
    {
        private readonly Data.IDataContext _dataContext = dataContext;

        public async Task Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var payment = (await _dataContext.Payments
                .Include(p => p.Person)
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken))
                ?? throw new NotFoundException();

            payment.Person.Balance -= payment.Amount;
            _dataContext.Payments.Remove(payment);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}