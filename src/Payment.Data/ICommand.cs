using Payment.Data.Session;

namespace Payment.Data
{
    public interface ICommand
    {
        void Execute(ISession session);
    }
}
