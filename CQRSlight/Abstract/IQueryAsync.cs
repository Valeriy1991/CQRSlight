using System.Threading.Tasks;

namespace CQRSlight.Abstract
{
    public interface IQueryAsync<in TRequest, TResult>
    {
        Task<TResult> GetAsync(TRequest request);
    }

    public interface IQueryAsync<TResult>
    {
        Task<TResult> GetAsync();
    }
}