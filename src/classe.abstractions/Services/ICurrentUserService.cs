using System.Security.Claims;

namespace ClassE.Services
{
    public interface ICurrentUserService
    {
        string AuthenticationScheme { get; }
        bool IsAdmin { get; }
        bool IsAuthenticated { get; }

        Task SignInAsync(ClaimsPrincipal principal);
    }
}