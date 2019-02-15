using System;
using System.Threading.Tasks;
using CQRSlight.Abstract;
using DbConn.DbExecutor.Abstract;
using Ether.Outcomes;

namespace CQRSlight.Db.Abstract
{
    public abstract class DbCheckerAsync<TEntity> : ICheckerAsync<TEntity>
    {
        protected IDbExecutor DbExecutor { get; }

        protected DbCheckerAsync(IDbExecutor dbExecutor)
        {
            if (dbExecutor == null)
                throw new ArgumentNullException(nameof(dbExecutor));
            DbExecutor = dbExecutor;
        }

        public abstract Task<IOutcome> CheckAsync(TEntity entity);
    }
}