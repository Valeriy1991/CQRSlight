using System;
using CQRSlight.Abstract;
using DbConn.DbExecutor.Abstract;
using Ether.Outcomes;

namespace CQRSlight.Db.Abstract
{
    public abstract class DbChecker<TEntity> : IChecker<TEntity>
    {
        protected IDbExecutor DbExecutor { get; }

        protected DbChecker(IDbExecutor dbExecutor)
        {
            if (dbExecutor == null)
                throw new ArgumentNullException(nameof(dbExecutor));
            DbExecutor = dbExecutor;
        }

        public abstract IOutcome Check(TEntity entity);
    }
}