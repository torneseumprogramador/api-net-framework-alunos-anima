using Execricio.NETFramework.CRUD.Database.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace Execricio.NETFramework.CRUD.Database.Repository
{
    public class BaseRepository : IBaseRepository, IDisposable
    {
        private string _connectionString = "Data Source=ReservaDatabase.db;Version=3;";
        private SQLiteConnection _connection;

        /// <summary>
        /// Obtém a conexão com o banco de dados.
        /// </summary>
        /// <returns>A conexão com o banco de dados.</returns>
        public IDbConnection GetConnection()
        {
            _connection = new SQLiteConnection(_connectionString);
            _connection.Open();
            return _connection;
        }

        /// <summary>
        /// Obtém o status da conexão com o banco de dados.
        /// </summary>
        /// <returns>O o status da conexão com o banco de dados.</returns>
        public bool GetStatusConnection()
        {
            try
            {
                using (GetConnection())
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Cria um novo registro no banco de dados.
        /// </summary>
        /// <param name="entity">O objeto a ser criado.</param>
        /// <returns>True se a criação for bem-sucedida, False caso contrário.</returns>
        public virtual bool Salvar(object entity)
        {
            using (var connection = GetConnection())
            {
                return false;
            }
        }

        /// <summary>
        /// Retorna todos os registros do banco de dados.
        /// </summary>
        /// <returns>Uma coleção de objetos representando os registros do banco de dados.</returns>
        public virtual IEnumerable<object> Recuperar()
        {
            using (var connection = GetConnection())
            {
                return null;
            }
        }

        /// <summary>
        /// Retorna um registro do banco de dados com base no ID fornecido.
        /// </summary>
        /// <param name="id">O ID do registro.</param>
        /// <returns>O objeto representando o registro do banco de dados ou null se não encontrado.</returns>
        public virtual object Recuperar(int id)
        {
            using (var connection = GetConnection())
            {
                return null;
            }
        }

        /// <summary>
        /// Atualiza um registro existente no banco de dados.
        /// </summary>
        /// <param name="entity">O objeto a ser atualizado.</param>
        /// <returns>True se a atualização for bem-sucedida, False caso contrário.</returns>
        public virtual bool Atualizar(object entity)
        {
            using (var connection = GetConnection())
            {
                return false;
            }
        }

        /// <summary>
        /// Exclui um registro do banco de dados com base no ID fornecido.
        /// </summary>
        /// <param name="id">O ID do registro a ser excluído.</param>
        /// <returns>True se a exclusão for bem-sucedida, False caso contrário.</returns>
        public virtual bool Deletar(int id)
        {
            using (var connection = GetConnection())
            {
                return false;
            }
        }

        /// <summary>
        /// Libera os recursos utilizados pela conexão com o banco de dados.
        /// </summary>
        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
