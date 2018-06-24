using System.Collections.Generic;

namespace Payment.Data.Session
{
    public interface ISession
    {
        IEnumerable<T> Query<T>(string query, object param = null);
        void Execute(string query, object param = null);
    }
}