using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Qualite.Ingenieria.Authentication.Auth;
using Qualite.Ingenieria.Domain.Entities.Users;
using System.Security.Claims;

namespace Qualite.Ingenieria.Services.Users
{
    public class AuthenticationService : Domain.Services.Users.IAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SignInAsync(User user, bool isPersistent)
        {
            var claims = new List<Claim>();

            if (!string.IsNullOrEmpty(user.Username))
                claims.Add(new Claim(ClaimTypes.Name, user.Username, ClaimValueTypes.String, QualiteAuthenticationDefaults.ClaimsIssuer));

            ClaimsIdentity userIdentity = new(claims, QualiteAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal userPrincipal = new(userIdentity);

            AuthenticationProperties authenticationProperties = new()
            {
                IsPersistent = isPersistent,
                IssuedUtc = DateTime.UtcNow
            };

            await _httpContextAccessor.HttpContext.SignInAsync(QualiteAuthenticationDefaults.AuthenticationScheme, userPrincipal, authenticationProperties);
        }
    }
}
