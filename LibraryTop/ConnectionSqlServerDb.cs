using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryTop
{
    /// <summary>
    /// Connect and execute operations with database SqlServer.
    /// </summary>
    class ConnectionSqlServerDb : IDataBase
    {
        private string _connectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlTransaction transaction;

        /// <summary>
        /// Constructor. Receive with argument the connection string.
        /// </summary>
        /// <param name="connectionString">Connection string SqlServer. </param>
        public ConnectionSqlServerDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Execute a delete in data base.
        /// </summary>
        /// <param name="query">Query will be execute.</param>
        /// <returns>Return the number rows affecteds.</returns>
        public string Delete(string query)
        {
            using (connection = new SqlConnection(_connectionString))
            using (command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    int numberRowsAffecteds = command.ExecuteNonQuery();
                    transaction.Commit();

                    return numberRowsAffecteds.ToString();
                }
                catch (InvalidCastException ex)
                {
                    transaction.Rollback();
                    return $"Error when delete data. Message: {ex.Message}";
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    return $"Error when delete data. Message: {ex.Message}";
                }
                catch (InvalidOperationException ex)
                {
                    transaction.Rollback();
                    return $"Error when delete data. Message: {ex.Message}";
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Execute a insert in data base.
        /// </summary>
        /// <param name="query">Query will be execute.</param>
        /// <returns>Return the number rows affecteds.</returns>
        public string Insert(string query)
        {
            using (connection = new SqlConnection(_connectionString))
            using (command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    int numberRowsAffecteds = command.ExecuteNonQuery();
                    transaction.Commit();

                    return numberRowsAffecteds.ToString();
                }
                catch (InvalidCastException ex)
                {
                    transaction.Rollback();
                    return $"Error when insert data. Message: {ex.Message}";
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    return $"Error when insert data. Message: {ex.Message}";
                }
                catch (InvalidOperationException ex)
                {
                    transaction.Rollback();
                    return $"Error when insert data. Message: {ex.Message}";
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Execute a select in data base.
        /// </summary>
        /// <param name="query">Query will be execute.</param>
        /// <returns>Return a datatable.</returns>
        public DataTable Select(string query)
        {
            DataTable table = new DataTable();

            using (connection = new SqlConnection(_connectionString))
            using (command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    table.Load(command.ExecuteReader());

                    return table;
                }
                catch (InvalidCastException ex)
                {
                    transaction.Rollback();
                    throw new InvalidCastException($"Error when update data. Message: {ex.Message}");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception($"Error when update data. Message: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Execute a update in data base.
        /// </summary>
        /// <param name="query">Query will be execute.</param>
        /// <returns>Return the number rows affecteds.</returns>
        public string Update(string query)
        {
            using (connection = new SqlConnection(_connectionString))
            using (command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    int numberRowsAffecteds = command.ExecuteNonQuery();
                    transaction.Commit();

                    return numberRowsAffecteds.ToString();
                }
                catch (InvalidCastException ex)
                {
                    transaction.Rollback();
                    return $"Error when update data. Message: {ex.Message}";
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    return $"Error when update data. Message: {ex.Message}";
                }
                catch (InvalidOperationException ex)
                {
                    transaction.Rollback();
                    return $"Error when update data. Message: {ex.Message}";
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
