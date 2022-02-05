using Qualite.Ingenieria.Domain.Entities.Users;

namespace Qualite.Ingenieria.Domain.Services.Users
{
    public interface IAuthenticationService
    {
        Task SignInAsync(User user, bool isPersistent);
    }
}
