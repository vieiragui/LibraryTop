using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace LibraryTop
{
    /// <summary>
    /// Connect and execute operations with database Oracle.
    /// </summary>
    public class ConnectionOracleDb : IDataBase
    {
        private string _connectionString = default;
        private OracleConnection connection;
        private OracleCommand command;

        /// <summary>
        /// Constructor. Receive with argument the connection string.
        /// </summary>
        /// <param name="connectionString">Connection string Oracle. </param>
        public ConnectionOracleDb(string connectionString)
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
            using (connection = new OracleConnection(_connectionString))
            using (command = new OracleCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    connection.BeginTransaction();
                    int numberRowsAffecteds = command.ExecuteNonQuery();
                    command.Transaction.Commit();

                    return numberRowsAffecteds.ToString();
                }
                catch (InvalidOperationException ex)
                {
                    return $"Error when deleting data. Message: {ex.Message}";
                }
                catch (Exception ex)
                {
                    return $"Error when deleting data. Message: {ex.Message}";
                }
                finally
                {
                    connection.Clone();
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
            using (connection = new OracleConnection(_connectionString))
            using (command = new OracleCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    connection.BeginTransaction();
                    int numberRowsAffecteds = command.ExecuteNonQuery();
                    command.Transaction.Commit();

                    return numberRowsAffecteds.ToString();
                }
                catch (InvalidOperationException ex)
                {
                    command.Transaction.Rollback();
                    return $"Error when insert data. Message {ex.Message}";
                }
                catch (Exception ex)
                {
                    command.Transaction.Rollback();
                    return $"Error when insert data. Message {ex.Message}";
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
            DataTable resultQuery = new DataTable();
            using (connection = new OracleConnection(_connectionString))
            using (command = new OracleCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    connection.BeginTransaction();
                    resultQuery.Load(command.ExecuteReader());

                    return resultQuery;
                }catch(InvalidOperationException ex)
                {
                    throw new Exception($"Error when select data. Message: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error when select data. Message: {ex.Message}");
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
            using (connection = new OracleConnection(_connectionString))
            using (command = new OracleCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    connection.BeginTransaction();
                    int numberRowsAffeteds = command.ExecuteNonQuery();
                    command.Transaction.Commit();

                    return numberRowsAffeteds.ToString();
                }
                catch(InvalidOperationException ex)
                {
                    command.Transaction.Rollback();
                    return $"Error when update data. Message: {ex.Message}";
                }
                catch (Exception ex)
                {
                    command.Transaction.Rollback();
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
