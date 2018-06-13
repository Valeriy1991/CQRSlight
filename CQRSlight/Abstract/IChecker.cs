using System;
using Ether.Outcomes;

namespace CQRSlight.Abstract
{
    public interface IChecker<in TEntity>
    {
        IOutcome Check(TEntity entity);
    }
}