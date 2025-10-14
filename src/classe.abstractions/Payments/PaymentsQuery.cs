using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Payments
{
    public record PaymentsQuery : Types.BaseQuery<PaymentResult>
    {
        public int? Person { get; init; }
    }

    internal class PaymentsQueryHandler(
        Data.IDataContext dataContext,
        IMapper mapper) : IRequestHandler<PaymentsQuery, Types.SearchResult<PaymentResult>>
    {
        private readonly Data.IDataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public async Task<Types.SearchResult<PaymentResult>> Handle(PaymentsQuery request, CancellationToken cancellationToken)
        {
            var query = _dataContext.Payments.AsQueryable();

            if (request.Person.HasValue)
                query = query.Where(p => p.PersonId == request.Person.Value);

            return new()
            {
                Total = await query.CountAsync(cancellationToken),
                Results = await query
                    .OrderByDescending(p => p.Created)
                    .Skip(request.Offset)
                    .Take(request.Limit)
                    .ProjectTo<PaymentResult>(_mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken),
            };
        }
    }
}