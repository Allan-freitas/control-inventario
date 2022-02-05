using Microsoft.AspNetCore.Mvc;
using Qualite.Ingenieria.Domain.Entities.Users;

namespace Qualite.Ingenieria.Domain.Services.Users
{
    public interface IUserService
    {
        Task<IQueryable<User>> FindAllAsync();

        Task<User> FindByIdAsync(long id);

        Task<long> CreateAsync(User user);

        Task<bool> UpdateAsync(User user);

        Task<bool> DeleteAsync(long id);

        Task<User> FindByUsername(string username);

        Task<User> FindByEmail(string email);         
    }
}
