using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryTop
{
    /// <summary>
    /// Conecta e executa operações com o banco de dados SqlServer.
    /// </summary>
    class ConnectionSqlServerDb : IDataBase
    {
        private string _connectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlTransaction transaction;

        /// <summary>
        /// Construtor. Recebe como argumento a string de conexão.
        /// </summary>
        /// <param name="connectionString">String de conexão do SqlServer. Pode ser encontrada no site www.connectionstring.com</param>
        public ConnectionSqlServerDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Execute o comando delete no banco de dados.
        /// </summary>
        /// <param name="query">Sql que será executado.</param>
        /// <returns>Retorna o número de linhas afetadas</returns>
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
        /// Inseri dados no banco de dados.
        /// </summary>
        /// <param name="query">Sql que será executado.</param>
        /// <returns>Retorna o número de linhas afetadas.</returns>
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
        /// Executa um select no banco de dados.
        /// </summary>
        /// <param name="query">Sql que será executado.</param>
        /// <returns>Retorna um DataTable</returns>
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
        /// Executa um select retornando todas as colunas da tabela.
        /// </summary>
        /// <param name="nameTable">Nome da tabela onde será executado o select.</param>
        /// <returns>Retorna um DataTable com todas as colunas da tabela.</returns>
        public DataTable SelectAll(string nameTable)
        {
            string query = $"select * from {nameTable}";
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
        /// Executa um select retornando as colunas que foram passadas como argumento.
        /// </summary>
        /// <param name="columns">Colunas que serão usadas para o select</param>
        /// <param name="nameTable">Nome da tabela onde será executado o select.</param>
        /// <returns>Retorna um DataTable com as colunas especificadas.</returns>
        public DataTable SelectSomeColumns(string nameTable, params string[] columns)
        {
            string joinColumns = string.Join(",", columns);
            string query = $"select {joinColumns} from {nameTable}";
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
        /// Executa um update na base de dados.
        /// </summary>
        /// <param name="query">Sql que será executado.</param>
        /// <returns>Retorna o número de linhas afetadas.</returns>
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
