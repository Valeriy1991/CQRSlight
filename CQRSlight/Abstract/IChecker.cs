﻿using System;
using Ether.Outcomes;

namespace CQRSlight.Abstract
{
    public interface IChecker<in TEntity>
    {
        [Obsolete("You must use the Check method instead of this. This method will be removed in 1.0.2")]
        IOutcome IsValid(TEntity entity);

        IOutcome Check(TEntity entity);
    }
}