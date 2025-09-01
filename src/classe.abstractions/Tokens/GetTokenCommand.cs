using MediatR;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace ClassE.Tokens
{
    public record GetTokenCommand : IRequest<Types.TokenResult>
    {
        public ClaimsIdentity User { get; init; } = null!;
    }

    internal class GetTokenCommandHandler(
        Data.IDataContext dataContext,
        IOptions<Types.Options> options,
        Services.IUsersService usersService) : IRequestHandler<GetTokenCommand, Types.TokenResult>
    {
        private readonly Data.IDataContext _dataContext = dataContext;
        private readonly Types.Options _options = options.Value;
        private readonly Services.IUsersService _usersService = usersService;

        public Task<Types.TokenResult> Handle(GetTokenCommand request, CancellationToken cancellationToken)
        {
            var user = _dataContext.Users(_options);

            return Task.FromResult(user.ToResult(_usersService.CreateJwt(request.User)));
        }
    }
}