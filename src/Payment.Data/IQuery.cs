using Payment.Data.Session;

namespace Payment.Data
{
    public interface IQuery<out T>
    {
        T Execute(ISession session);
    }
}
