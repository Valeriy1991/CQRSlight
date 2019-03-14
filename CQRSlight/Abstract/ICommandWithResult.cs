using Ether.Outcomes;

namespace CQRSlight.Abstract
{
    public interface ICommandWithResult<TResult>
    {
        IOutcome<TResult> Execute();
    }

    public interface ICommandWithResult<in TCommandRequest, TResult>
    {
        IOutcome<TResult> Execute(TCommandRequest commandRequest);
    }
}