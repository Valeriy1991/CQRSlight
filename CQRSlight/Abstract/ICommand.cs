using Ether.Outcomes;

namespace CQRSlight.Abstract
{
    public interface ICommand<in TCommandContext, TResult>
    {
        IOutcome<TResult> Execute(TCommandContext commandContext);
    }

    public interface ICommand<in TCommandContext>
    {
        IOutcome Execute(TCommandContext commandContext);
    }
}