using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace LibraryTop
{
    /// <summary>
    /// Conecta e executa operações com o banco de dados MySql.
    /// </summary>
    public class ConnectionMySqlDb : IDataBase
    {
        private string _connectionString = default;
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlTransaction transaction;

        /// <summary>
        /// Construtor. Recebe como argumento a string de conexão.
        /// </summary>
        /// <param name="connectionString">String de conexão do MySql. Pode ser encontrada no site www.connectionstring.com</param>
        public ConnectionMySqlDb(string connectionString)
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
            using (connection = new MySqlConnection(_connectionString))
            using (command = new MySqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    int numberRowsAffecteds = command.ExecuteNonQuery();
                    transaction.Commit();

                    return numberRowsAffecteds.ToString();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return $"Error when deleting data. Message:{ex.Message}";
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
            using (connection = new MySqlConnection(_connectionString))
            using (command = new MySqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    int numberRowsAffecteds = command.ExecuteNonQuery();
                    transaction.Commit();

                    return numberRowsAffecteds.ToString();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return $"Error when insert data. Message:{ex.Message}";
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
        /// Executa um select retornando todas as colunas da tabela.
        /// </summary>
        /// <param name="nameTable">Nome da tabela onde será executado o select.</param>
        /// <returns>Retorna um DataTable com todas as colunas da tabela.</returns>
        public DataTable SelectAll(string nameTable)
        {
            string query = $"select * from {nameTable}";
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
        /// Executa um select retornando as colunas que foram passadas como argumento.
        /// </summary>
        /// <param name="columns">Colunas que serão usadas para o select</param>
        /// <param name="nameTable">Nome da tabela onde será executado o select.</param>
        /// <returns>Retorna um DataTable com as colunas especificadas.</returns>
        public DataTable SelectSomeColumns(string nameTable, params string[] columns)
        {
            string joinColumns = string.Join(",", columns);
            string query = $"select {joinColumns} from {nameTable}";
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
        /// Executa um update na base de dados.
        /// </summary>
        /// <param name="query">Sql que será executado.</param>
        /// <returns>Retorna o número de linhas afetadas.</returns>
        public string Update(string query)
        {
            using (connection = new MySqlConnection(_connectionString))
            using (command = new MySqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    int numberRowsAffecteds = command.ExecuteNonQuery();
                    transaction.Commit();

                    return numberRowsAffecteds.ToString();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
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
