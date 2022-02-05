using System.Data;

namespace Qualite.Ingenieria.Data.Repositories
{
    public abstract class RepositoryBase
    {
        protected IDbTransaction Transaction { get; private set; }
        protected IDbConnection? Connection { get { return Transaction.Connection; } }

        public RepositoryBase(IDbTransaction transaction)
        {
            Transaction = transaction;
        }
    }
}
