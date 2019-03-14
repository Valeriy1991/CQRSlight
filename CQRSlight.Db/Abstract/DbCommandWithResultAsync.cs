using System;
using System.Threading.Tasks;
using CQRSlight.Abstract;
using DbConn.DbExecutor.Abstract;
using Ether.Outcomes;

namespace CQRSlight.Db.Abstract
{
    public abstract class DbCommandWithResultAsync<TResult> : ICommandWithResultAsync<TResult>
    {
        protected IDbExecutor DbExecutor { get; }

        protected DbCommandWithResultAsync(IDbExecutor dbExecutor)
        {
            if (dbExecutor == null)
                throw new ArgumentNullException(nameof(dbExecutor));
            DbExecutor = dbExecutor;
        }

        public abstract Task<IOutcome<TResult>> ExecuteAsync();
    }

    public abstract class DbCommandWithResultAsync<TCommandRequest, TResult> :
        ICommandWithResultAsync<TCommandRequest, TResult>
    {
        protected IDbExecutor DbExecutor { get; }

        protected DbCommandWithResultAsync(IDbExecutor dbExecutor)
        {
            if (dbExecutor == null)
                throw new ArgumentNullException(nameof(dbExecutor));
            DbExecutor = dbExecutor;
        }

        public abstract Task<IOutcome<TResult>> ExecuteAsync(TCommandRequest commandRequest);
    }
}