using System;
using CQRSlight.Abstract;
using DbConn.DbExecutor.Abstract;

namespace CQRSlight.Db.Abstract
{
    public abstract class DbQuery<TContext, TResult> : IQuery<TContext, TResult>
    {
        protected IDbExecutor DbExecutor { get; }

        protected DbQuery(IDbExecutor dbExecutor)
        {
            if (dbExecutor == null)
                throw new ArgumentNullException(nameof(dbExecutor));
            DbExecutor = dbExecutor;
        }

        public abstract TResult Get(TContext context);
    }

    public abstract class DbQuery<TResult> : IQuery<TResult>
    {
        protected IDbExecutor DbExecutor { get; }

        protected DbQuery(IDbExecutor dbExecutor)
        {
            if (dbExecutor == null)
                throw new ArgumentNullException(nameof(dbExecutor));
            DbExecutor = dbExecutor;
        }

        public abstract TResult Get();
    }
}