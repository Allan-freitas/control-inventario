using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using Qualite.Ingenieria.Data.Repositories.Users;
using Qualite.Ingenieria.Data.Settings;
using Qualite.Ingenieria.Domain.Repositories.Users;
using Qualite.Ingenieria.Domain.UnitOfWork;
using System.Data;

namespace Qualite.Ingenieria.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _dispose;
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private IUserRepository? _userRepository;

        public UnitOfWork(IOptions<DataBaseSettings> config)
        {
            _connection = new MySqlConnection(config.Value.ConnectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();            
        }

        public IUserRepository UserRepository 
        { 
            get 
            {
                return _userRepository ??= (_userRepository = new UserRepository(_transaction)); 
            } 
        }

        public void Commit()
        {
            try
            {                
                _transaction.Commit();
            }
            catch
            {                 
                _transaction.Rollback();
                throw;
            }
            finally
            {                
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();                
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_dispose)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();                        
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();                        
                    }
                }
                _dispose = true;
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
