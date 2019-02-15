using System;
using System.Threading.Tasks;
using CQRSlight.Abstract;
using DbConn.DbExecutor.Abstract;

namespace CQRSlight.Db.Abstract
{
    public abstract class DbQueryAsync<TRequest, TResult> : IQueryAsync<TRequest, TResult>
    {
        protected IDbExecutor DbExecutor { get; }

        protected DbQueryAsync(IDbExecutor dbExecutor)
        {
            if (dbExecutor == null)
                throw new ArgumentNullException(nameof(dbExecutor));
            DbExecutor = dbExecutor;
        }

        public abstract Task<TResult> GetAsync(TRequest request);
    }

    public abstract class DbQueryAsync<TResult> : IQueryAsync<TResult>
    {
        protected IDbExecutor DbExecutor { get; }

        protected DbQueryAsync(IDbExecutor dbExecutor)
        {
            if (dbExecutor == null)
                throw new ArgumentNullException(nameof(dbExecutor));
            DbExecutor = dbExecutor;
        }

        public abstract Task<TResult> GetAsync();
    }
}