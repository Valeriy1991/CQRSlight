using System;
using DbConn.DbExecutor.Abstract;
using Ether.Outcomes;

namespace CQRSlight.Db.Abstract
{
    public interface IDbChecker<in TEntity>
    {
        [Obsolete("You must use the Check method instead of this. This method will be removed in 1.0.2")]
        IOutcome IsValid(IDbExecutor dbExecutor, TEntity entity);

        IOutcome Check(IDbExecutor dbExecutor, TEntity entity);
    }
}