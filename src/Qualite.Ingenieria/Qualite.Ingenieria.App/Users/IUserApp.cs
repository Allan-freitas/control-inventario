using Microsoft.AspNetCore.Mvc;
using Qualite.Ingenieria.Domain.Entities.Users;

namespace Qualite.Ingenieria.App.Users
{
    public interface IUserApp
    {        
        Task<IActionResult> SignInUserAsync(User user, string returnUrl, bool isPersist = false);

        Task<UserLoginResults> ValidateUserAsync(string? usernameOrEmail, string? password);

        Task<User> FindByUsername(string username);

        Task<User> FindByEmail(string email);
    }
}
