using System.Threading.Tasks;
using Ether.Outcomes;

namespace CQRSlight.Abstract
{
    public interface ICommandAsync
    {
        Task<IOutcome> ExecuteAsync();
    }

    public interface ICommandAsync<in TCommandRequest>
    {
        Task<IOutcome> ExecuteAsync(TCommandRequest commandRequest);
    }
}