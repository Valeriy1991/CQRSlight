using Ether.Outcomes;

namespace CQRSlight.Abstract
{
    public interface ICommand<in TCommandContext>
    {
        IOutcome Execute(TCommandContext commandContext);
    }
}