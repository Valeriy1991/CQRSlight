namespace CQRSlight.Abstract
{
    public interface IQuery<in TRequest, out TResult>
    {
        TResult Get(TRequest request);
    }

    public interface IQuery<out TResult>
    {
        TResult Get();
    }
}