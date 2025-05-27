using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Bookings
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
            var rows = await _dataContext.Bookings
                .Where(b => b.Id == request.Id)
                .ExecuteDeleteAsync(cancellationToken);

            if (rows == 0)
                throw new NotFoundException();
        }
    }
}