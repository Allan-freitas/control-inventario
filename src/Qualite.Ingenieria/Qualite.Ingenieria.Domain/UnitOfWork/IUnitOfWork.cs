using Qualite.Ingenieria.Domain.Repositories.Users;

namespace Qualite.Ingenieria.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }

        void Commit();
    }
}
