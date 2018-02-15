using Ether.Outcomes;

namespace CQRSlight.Abstract
{
    public interface IChecker<in TEntity>
    {
        IOutcome IsValid(TEntity entity);
    }
}