using MediatR;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace ClassE.Login
{
    public record LoginCommand : IRequest<Types.TokenResult>
    {
        public string Username { get; init; } = null!;

        public string Password { get; init; } = null!;
    }

    internal class LoginCommandHandler(
        Data.IDataContext dataContext,
        IOptions<Types.Options> options,
        Services.IUsersService usersService,
        Services.ICurrentUserService currentUserService) : IRequestHandler<LoginCommand, Types.TokenResult>
    {
        private readonly Data.IDataContext _dataContext = dataContext;
        private readonly Types.Options _options = options.Value;
        private readonly Services.IUsersService _usersService = usersService;
        private readonly Services.ICurrentUserService _currentUserService = currentUserService;

        public async Task<Types.TokenResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = _dataContext.Users(_options, request.Username);

            if (user != null && _usersService.Authenticate(user.Password, request.Password))
            {
                if (_usersService.ShouldUpgrade(user.Password))
                {
                    user.Password = _usersService.HashPassword(request.Password!);
                }

                var userId = new ClaimsIdentity(
                [
                    new ("userid",user.Id.ToString()),
                    new (ClaimTypes.Role, "Admin")
                ], _currentUserService.AuthenticationScheme);

                await _currentUserService.SignInAsync(new(userId));

                return user.ToResult(_usersService.CreateJwt(userId));
            }

            return new()
            {
                Success = false,
            };
        }
    }
}