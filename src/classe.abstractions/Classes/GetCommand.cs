using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Classes
{
    public record GetCommand : IRequest<ClassResult>
    {
        public int Id { get; init; }
    }

    internal class GetCommandHandler(
        Data.IDataContext dataContext,
        IMapper mapper) : IRequestHandler<GetCommand, ClassResult>
    {
        private readonly Data.IDataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public async Task<ClassResult> Handle(GetCommand request, CancellationToken cancellationToken)
        {
            return (await _dataContext.Class
                .Where(c => c.Id == request.Id)
                .ProjectTo<ClassResult>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken))
                ?? throw new NotFoundException();
        }
    }
}