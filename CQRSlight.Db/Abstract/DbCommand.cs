using System;
using CQRSlight.Abstract;
using DbConn.DbExecutor.Abstract;
using Ether.Outcomes;

namespace CQRSlight.Db.Abstract
{
    public abstract class DbCommand : ICommand
    {
        protected IDbExecutor DbExecutor { get; }

        protected DbCommand(IDbExecutor dbExecutor)
        {
            if (dbExecutor == null)
                throw new ArgumentNullException(nameof(dbExecutor));
            DbExecutor = dbExecutor;
        }

        public abstract IOutcome Execute();
    }

    public abstract class DbCommand<TCommandRequest> : ICommand<TCommandRequest>
    {
        protected IDbExecutor DbExecutor { get; }

        protected DbCommand(IDbExecutor dbExecutor)
        {
            if (dbExecutor == null)
                throw new ArgumentNullException(nameof(dbExecutor));
            DbExecutor = dbExecutor;
        }

        public abstract IOutcome Execute(TCommandRequest commandRequest);
    }
}