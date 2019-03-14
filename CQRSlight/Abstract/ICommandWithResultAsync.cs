using System.Threading.Tasks;
using Ether.Outcomes;

namespace CQRSlight.Abstract
{
    public interface ICommandWithResultAsync<TResult>
    {
        Task<IOutcome<TResult>> ExecuteAsync();
    }

    public interface ICommandWithResultAsync<in TCommandRequest, TResult>
    {
        Task<IOutcome<TResult>> ExecuteAsync(TCommandRequest commandRequest);
    }
}