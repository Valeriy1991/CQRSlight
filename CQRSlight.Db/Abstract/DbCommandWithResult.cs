using System;
using CQRSlight.Abstract;
using DbConn.DbExecutor.Abstract;
using Ether.Outcomes;

namespace CQRSlight.Db.Abstract
{
    public abstract class DbCommandWithResult<TResult> : ICommandWithResult<TResult>
    {
        protected IDbExecutor DbExecutor { get; }

        protected DbCommandWithResult(IDbExecutor dbExecutor)
        {
            if (dbExecutor == null)
                throw new ArgumentNullException(nameof(dbExecutor));
            DbExecutor = dbExecutor;
        }

        public abstract IOutcome<TResult> Execute();
    }

    public abstract class DbCommandWithResult<TCommandRequest, TResult> : 
        ICommandWithResult<TCommandRequest, TResult>
    {
        protected IDbExecutor DbExecutor { get; }

        protected DbCommandWithResult(IDbExecutor dbExecutor)
        {
            if (dbExecutor == null)
                throw new ArgumentNullException(nameof(dbExecutor));
            DbExecutor = dbExecutor;
        }

        public abstract IOutcome<TResult> Execute(TCommandRequest commandRequest);
    }
}