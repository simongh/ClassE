using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace ClassE.Services
{
    internal class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

        public string AuthenticationScheme => CookieAuthenticationDefaults.AuthenticationScheme;

        public bool IsAdmin => _httpContextAccessor.HttpContext!.User.IsInRole("Admin");

        public Task SignInAsync(ClaimsPrincipal principal)
        {
            return _httpContextAccessor.HttpContext?.SignInAsync(principal) ?? Task.CompletedTask;
        }
    }
}