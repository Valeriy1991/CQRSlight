using System.Threading.Tasks;
using Ether.Outcomes;

namespace CQRSlight.Abstract
{
    public interface ICommandAsync<in TCommandContext, TResult>
    {
        Task<IOutcome<TResult>> ExecuteAsync(TCommandContext commandContext);
    }

    public interface ICommandAsync<in TCommandContext>
    {
        Task<IOutcome> ExecuteAsync(TCommandContext commandContext);
    }
}