using System;
using System.Data;
using System.Data.SqlClient;

namespace Payment.Data.Dapper
{
    public class DapperContext : IDapperContext
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public DapperContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbTransaction DbTransaction { get; set; }

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                    _connection = new SqlConnection(_connectionString);

                if (string.IsNullOrWhiteSpace(_connection.ConnectionString))
                    _connection.ConnectionString = _connectionString;

                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                return _connection;
            }
        }

        public IDbTransaction BeginTransaction()
        {
            if (DbTransaction == null || DbTransaction.Connection == null)
                DbTransaction = Connection.BeginTransaction();

            return DbTransaction;
        }

        public T Transaction<T>(Func<IDbTransaction, T> query)
        {
            DbTransaction = BeginTransaction();

            try
            {
                var result = query(DbTransaction);

                DbTransaction.Commit();

                return result;
            }
            catch
            {
                DbTransaction.Rollback();
                throw;
            }
            finally
            {
                if (DbTransaction != null)
                {
                    DbTransaction.Dispose();
                    DbTransaction = null;
                }

                if (_connection != null && _connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                    _connection = null;
                }
            }
        }

        public void Commit()
        {
            try
            {
                DbTransaction.Commit();
                DbTransaction.Dispose();
                DbTransaction = null;
            }
            catch (Exception ex)
            {
                if (DbTransaction != null && DbTransaction.Connection != null)
                    Rollback();

                throw new NullReferenceException("Tried Commit on closed Transaction", ex);
            }
        }

        public void Rollback()
        {
            try
            {
                DbTransaction.Rollback();
                DbTransaction.Dispose();
                DbTransaction = null;
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Tried Rollback on closed Transaction", ex);
            }
        }

        public void Dispose()
        {
            if (DbTransaction != null)
            {
                DbTransaction.Dispose();
                DbTransaction = null;
            }

            if (_connection != null && _connection.State != ConnectionState.Closed)
            {
                _connection.Close();
                _connection = null;
            }
        }
    }
}