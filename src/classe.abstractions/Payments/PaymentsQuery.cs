using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClassE.Models;
using ClassE.Types;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Payments
{
    public record PaymentsQuery : Types.BaseQuery<Models.PaymentModel>
    {
        public int Person { get; init; }
    }

    internal class PaymentsQueryHandler(
        Data.IDataContext dataContext,
        IMapper mapper) : IRequestHandler<PaymentsQuery, Types.SearchResult<Models.PaymentModel>>
    {
        private readonly Data.IDataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public async Task<SearchResult<PaymentModel>> Handle(PaymentsQuery request, CancellationToken cancellationToken)
        {
            var query = _dataContext.Payments
                .Where(p => p.PersonId == request.Person);

            return new()
            {
                Total = await query.CountAsync(cancellationToken),
                Results = await query
                    .OrderByDescending(p => p.Created)
                    .Skip(request.Offset)
                    .Take(request.Limit)
                    .ProjectTo<Models.PaymentModel>(_mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken),
            };
        }
    }
}