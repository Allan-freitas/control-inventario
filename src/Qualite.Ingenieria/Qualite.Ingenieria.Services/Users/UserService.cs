using Qualite.Ingenieria.Domain.Entities.Users;
using Qualite.Ingenieria.Domain.Services.Users;
using Qualite.Ingenieria.Domain.UnitOfWork;

namespace Qualite.Ingenieria.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;             

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }

        public async Task<long> CreateAsync(User user)
        {
            return await _unitOfWork.UserRepository.CreateAsync(user);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return await _unitOfWork.UserRepository.DeleteAsync(id);
        }

        public async Task<IQueryable<User>> FindAllAsync()
        {
            return await _unitOfWork.UserRepository.FindAllAsync();
        }

        public async Task<User> FindByEmail(string email)
        {
            return await _unitOfWork.UserRepository.FindByEmail(email);
        }

        public async Task<User> FindByIdAsync(long id)
        {
            return await _unitOfWork.UserRepository.FindByIdAsync(id);
        }

        public async Task<User> FindByUsername(string username)
        {
            return await _unitOfWork.UserRepository.FindByUsername(username);
        }

        public async Task<bool> UpdateAsync(User user)
        {
            return await _unitOfWork.UserRepository.UpdateAsync(user);
        }
    }
}
