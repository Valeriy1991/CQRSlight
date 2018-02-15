namespace CQRSlight.Abstract
{
    public interface IQuery<in TContext, out TResult>
    {
        TResult Get(TContext context);
    }

    public interface IQuery<out TResult>
    {
        TResult Get();
    }
}