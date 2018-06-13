using System;
using DbConn.DbExecutor.Abstract;
using Ether.Outcomes;

namespace CQRSlight.Db.Abstract
{
    public interface IDbChecker<in TEntity>
    {
        IOutcome Check(IDbExecutor dbExecutor, TEntity entity);
    }
}