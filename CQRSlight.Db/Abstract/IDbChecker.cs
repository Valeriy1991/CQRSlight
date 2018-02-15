using DbConn.DbExecutor.Abstract;
using Ether.Outcomes;

namespace CQRSlight.Db.Abstract
{
    public interface IDbChecker<in TEntity>
    {
        IOutcome IsValid(IDbExecutor dbExecutor, TEntity entity);
    }
}