using Dapper;
using Qualite.Ingenieria.Domain.Entities.Users;
using Qualite.Ingenieria.Domain.Repositories.Users;
using System.Data;

namespace Qualite.Ingenieria.Data.Repositories.Users
{
    public class UserRepository : Repository<User>, IUserRepository
    {        
        public UserRepository(IDbTransaction dbTransaction) : base(dbTransaction) { }

        public async Task<bool> DeleteUserAsync(long id)
        {
            return await DeleteAsync(id);
        }

        public async Task<User> FindByEmail(string email)
        {
            return await Connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM USER " +
                $"WHERE Email = @Email", new { Email = email });
        }

        public async Task<User> FindByUsername(string username)
        {
            return await Connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM USER " +
                $"WHERE UserName = @Username", new { Username = username });
        }

        public async Task<User> GetUserAsync(long id)
        {
            return await FindByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await FindAllAsync();
        }

        public async Task<long> InsertUserAsync(User user)
        {
            return await CreateAsync(user);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            return await UpdateAsync(user);
        }
    }
}
