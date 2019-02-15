using System;
using System.Threading.Tasks;
using CQRSlight.Abstract;
using DbConn.DbExecutor.Abstract;
using Ether.Outcomes;

namespace CQRSlight.Db.Abstract
{
    public abstract class DbCommandAsync<TCommandContext, TResult> : ICommandAsync<TCommandContext, TResult>
    {
        protected IDbExecutor DbExecutor { get; }

        protected DbCommandAsync(IDbExecutor dbExecutor)
        {
            if (dbExecutor == null)
                throw new ArgumentNullException(nameof(dbExecutor));
            DbExecutor = dbExecutor;
        }

        public abstract Task<IOutcome<TResult>> ExecuteAsync(TCommandContext commandContext);
    }

    public abstract class DbCommandAsync<TCommandContext> : ICommandAsync<TCommandContext>
    {
        protected IDbExecutor DbExecutor { get; }

        protected DbCommandAsync(IDbExecutor dbExecutor)
        {
            if (dbExecutor == null)
                throw new ArgumentNullException(nameof(dbExecutor));
            DbExecutor = dbExecutor;
        }

        public abstract Task<IOutcome> ExecuteAsync(TCommandContext commandContext);
    }
}