using Ether.Outcomes;

namespace CQRSlight.Abstract
{

    public interface ICommand
    {
        IOutcome Execute();
    }

    public interface ICommand<in TCommandRequest>
    {
        IOutcome Execute(TCommandRequest commandRequest);
    }
}