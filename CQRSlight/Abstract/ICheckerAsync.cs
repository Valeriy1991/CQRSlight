using System;
using System.Threading.Tasks;
using Ether.Outcomes;

namespace CQRSlight.Abstract
{
    public interface ICheckerAsync<in TEntity>
    {
        Task<IOutcome> CheckAsync(TEntity entity);
    }
}