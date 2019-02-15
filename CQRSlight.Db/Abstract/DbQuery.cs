using System;
using CQRSlight.Abstract;
using DbConn.DbExecutor.Abstract;

namespace CQRSlight.Db.Abstract
{
    public abstract class DbQuery<TRequest, TResult> : IQuery<TRequest, TResult>
    {
        protected IDbExecutor DbExecutor { get; }

        protected DbQuery(IDbExecutor dbExecutor)
        {
            if (dbExecutor == null)
                throw new ArgumentNullException(nameof(dbExecutor));
            DbExecutor = dbExecutor;
        }

        public abstract TResult Get(TRequest request);
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