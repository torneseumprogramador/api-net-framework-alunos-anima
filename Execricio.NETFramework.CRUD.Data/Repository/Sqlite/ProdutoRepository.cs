using Execricio.NETFramework.CRUD.Data.Arguments;
using Execricio.NETFramework.CRUD.Data.Repository.Interfaces.Sqlite;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace Execricio.NETFramework.CRUD.Data.Repository.Sqlite
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        private static ProdutoRepository _instance;

        private ProdutoRepository() { }

        public static ProdutoRepository Instance
        {
            get
            {
                if (_instance is null)
                    _instance = new ProdutoRepository();
                return _instance;
            }
        }

        public bool AtualizarProduto(ProdutoArgument produto)
        {
            using (IDbConnection connection = GetConnection())
            {
                string sql = "UPDATE Produto SET Nome = @Nome, Descricao = @Descricao WHERE Id = @Id";
                return connection.Execute(sql, produto) > 0;
            }
        }

        public bool DeletarProduto(int id)
        {
            using (IDbConnection connection = GetConnection())
            {
                string sql = "DELETE FROM Produto WHERE Id = @Id";
                return connection.Execute(sql, new { Id = id }) > 0;
            }
        }

        public ProdutoArgument RecuperarProduto(int id)
        {
            using (IDbConnection connection = GetConnection())
            {
                string sql = "SELECT * FROM Produto WHERE Id = @Id";
                return connection.QuerySingleOrDefault<ProdutoArgument>(sql, new { Id = id });
            }
        }

        public IEnumerable<ProdutoArgument> RecuperarProdutos()
        {
            using (IDbConnection connection = GetConnection())
            {
                string sql = "SELECT * FROM Produto";
                return connection.Query<ProdutoArgument>(sql);
            }
        }

        public bool SalvarProduto(ProdutoArgument produto)
        {
            using (IDbConnection connection = GetConnection())
            {
                string sql = "INSERT INTO Produto (Nome, Descricao) VALUES (@Nome, @Descricao)";
                return connection.Execute(sql, produto) > 0;
            }
        }
    }
}
