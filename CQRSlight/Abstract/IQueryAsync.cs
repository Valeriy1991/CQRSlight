using System.Threading.Tasks;

namespace CQRSlight.Abstract
{
    public interface IQueryAsync<in TContext, TResult>
    {
        Task<TResult> GetAsync(TContext context);
    }

    public interface IQueryAsync<TResult>
    {
        Task<TResult> GetAsync();
    }
}