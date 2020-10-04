using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace LibraryTop
{
    /// <summary>
    /// Conecta e executa operações com o banco de dados Oracle.
    /// </summary>
    public class ConnectionOracleDb : IDataBase
    {
        private string _connectionString = default;
        private OracleConnection connection;
        private OracleCommand command;

        /// <summary>
        /// Construtor. Recebe como argumento a string de conexão.
        /// </summary>
        /// <param name="connectionString">String de conexão do Oracle. Pode ser encontrada no site www.connectionstring.com</param>
        public ConnectionOracleDb(string connectionString)
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
                    return $"Error when deleting data. Message: {ex.Message}";
                }
                catch (Exception ex)
                {
                    command.Transaction.Rollback();
                    return $"Error when deleting data. Message: {ex.Message}";
                }
                finally
                {
                    connection.Clone();
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
        /// Executa um select no banco de dados.
        /// </summary>
        /// <param name="query">Sql que será executado.</param>
        /// <returns>Retorna um DataTable</returns>
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
        /// Executa um select retornando todas as colunas da tabela.
        /// </summary>
        /// <param name="nameTable">Nome da tabela onde será executado o select.</param>
        /// <returns>Retorna um DataTable com todas as colunas da tabela.</returns>
        public DataTable SelectAll(string nameTable)
        {
            string query = $"select * from {nameTable}";
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
                }
                catch (InvalidOperationException ex)
                {
                    throw new Exception($"Erro ao executar o select. Mensagem do Erro: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao executar o select. Mensagem do Erro: {ex.Message}");
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
            using (connection = new OracleConnection(_connectionString))
            using (command = new OracleCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    connection.BeginTransaction();
                    resultQuery.Load(command.ExecuteReader());

                    return resultQuery;
                }
                catch (InvalidOperationException ex)
                {
                    throw new Exception($"Erro ao executar o select. Mensagem do Erro: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao executar o select. Mensagem do Erro: {ex.Message}");
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
