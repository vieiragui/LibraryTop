using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace LibraryTop
{
    class ConnectionMySqlDb : IDataBase
    {
        private string _connectionString = default;
        private MySqlConnection connection;
        private MySqlCommand command;

        /// <summary>
        /// Constructor. Receive with argument the connection string.
        /// </summary>
        /// <param name="connectionString">Connection string MySql.</param>
        public ConnectionMySqlDb(string connectionString)
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
            using (connection = new MySqlConnection(_connectionString))
            using (command = new MySqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    connection.BeginTransaction();
                    int numberRowsAffecteds = command.ExecuteNonQuery();
                    command.Transaction.Commit();

                    return numberRowsAffecteds.ToString();
                }
                catch (Exception ex)
                {
                    command.Transaction.Rollback();
                    return $"Error when deleting data. Message:{ex.Message}";
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
            using (connection = new MySqlConnection(_connectionString))
            using (command = new MySqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    connection.BeginTransaction();
                    int numberRowsAffecteds = command.ExecuteNonQuery();
                    command.Transaction.Commit();

                    return numberRowsAffecteds.ToString();
                }
                catch (Exception ex)
                {
                    command.Transaction.Rollback();
                    return $"Error when insert data. Message:{ex.Message}";
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
            using (connection = new MySqlConnection(_connectionString))
            using (command = new MySqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    connection.BeginTransaction();
                    resultQuery.Load(command.ExecuteReader());

                    return resultQuery;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error when deleting data. Message:{ex.Message}");
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
            using (connection = new MySqlConnection(_connectionString))
            using (command = new MySqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    connection.BeginTransaction();
                    int numberRowsAffecteds = command.ExecuteNonQuery();
                    command.Transaction.Commit();

                    return numberRowsAffecteds.ToString();
                }
                catch (Exception ex)
                {
                    command.Transaction.Rollback();
                    return $"Error when update data. Message:{ex.Message}";
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
