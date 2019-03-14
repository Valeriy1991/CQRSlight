using System;
using System.Threading.Tasks;
using CQRSlight.Abstract;
using DbConn.DbExecutor.Abstract;
using Ether.Outcomes;

namespace CQRSlight.Db.Abstract
{
    public abstract class DbCommandAsync : ICommandAsync
    {
        protected IDbExecutor DbExecutor { get; }

        protected DbCommandAsync(IDbExecutor dbExecutor)
        {
            if (dbExecutor == null)
                throw new ArgumentNullException(nameof(dbExecutor));
            DbExecutor = dbExecutor;
        }

        public abstract Task<IOutcome> ExecuteAsync();
    }

    public abstract class DbCommandAsync<TCommandRequest> : ICommandAsync<TCommandRequest>
    {
        protected IDbExecutor DbExecutor { get; }

        protected DbCommandAsync(IDbExecutor dbExecutor)
        {
            if (dbExecutor == null)
                throw new ArgumentNullException(nameof(dbExecutor));
            DbExecutor = dbExecutor;
        }

        public abstract Task<IOutcome> ExecuteAsync(TCommandRequest commandRequest);
    }
}