using Execricio.NETFramework.CRUD.Data.Arguments;
using Execricio.NETFramework.CRUD.Data.Repository.Interfaces.Sqlite;
using System.Collections.Generic;
using Dapper;
using System.Data;

namespace Execricio.NETFramework.CRUD.Data.Repository.Sqlite
{
    public class PrecoRepository : BaseRepository, IPrecoRepository
    {
        private static PrecoRepository _instance;

        private PrecoRepository() { }

        public static PrecoRepository Instance
        {
            get
            {
                if (_instance is null)
                    _instance = new PrecoRepository();
                return _instance;
            }

        }

        public bool AtualizarPreco(PrecoArgument preco)
        {
            using (IDbConnection connection = GetConnection())
            {
                string sql = "UPDATE Preco SET ProdutoId = @ProdutoId, Preco = @Preco, Data = @Data, Ativo = @Ativo WHERE Id = @Id";
                return connection.Execute(sql, preco) > 0;
            }
        }

        public bool DeletarPreco(int id)
        {
            using (IDbConnection connection = GetConnection())
            {
                string sql = "DELETE FROM Preco WHERE Id = @Id";
                return connection.Execute(sql, new { Id = id }) > 0;
            }
        }

        public PrecoArgument RecuperarPreco(int id)
        {
            using (IDbConnection connection = GetConnection())
            {
                string sql = "SELECT * FROM Preco WHERE Id = @Id";
                return connection.QuerySingleOrDefault<PrecoArgument>(sql, new { Id = id });
            }
        }

        public IEnumerable<PrecoArgument> RecuperarPrecos()
        {
            using (IDbConnection connection = GetConnection())
            {
                string sql = "SELECT * FROM Preco";
                return connection.Query<PrecoArgument>(sql);
            }
        }

        public bool SalvarPreco(PrecoArgument preco)
        {
            using (IDbConnection connection = GetConnection())
            {
                string sql = "INSERT INTO Preco (ProdutoId, Preco, Data, Ativo) VALUES (@ProdutoId, @Preco, @Data, @Ativo)";
                int rowsAffected = connection.Execute(sql, preco);
                return rowsAffected > 0;
            }
        }
    }
}
