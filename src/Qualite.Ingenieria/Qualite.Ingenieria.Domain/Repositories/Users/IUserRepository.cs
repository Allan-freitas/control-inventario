using Qualite.Ingenieria.Domain.Entities.Users;

namespace Qualite.Ingenieria.Domain.Repositories.Users
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(long id);
        Task<long> InsertUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(long id);
        Task<User> FindByUsername(string username);
        Task<User> FindByEmail(string email);
    }
}
