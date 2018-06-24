using System.Collections.Generic;
using Dapper;
using Payment.Data.Dapper;

namespace Payment.Data.Session
{
    public class Session : ISession
    {
        private readonly IDapperContext _context;

        public Session(string connectionString)
        {
            _context = new DapperContext(connectionString);
        }

        public Session(IDapperContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<T> Query<T>(string query, object param)
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;

            return _context.Transaction(transaction => _context.Connection.Query<T>(query, param, transaction));
        }

        public void Execute(string sql, object param)
        {
            _context.Transaction(transaction => _context.Connection.Execute(sql, param, transaction));
        }
    }
}
