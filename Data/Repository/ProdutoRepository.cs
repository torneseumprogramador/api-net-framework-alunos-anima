using Dapper;
using Data.Context;
using Data.Model;
using Npgsql;
using System.Data;

namespace Data.Repository
{
    public class ProdutoRepository
    {
        public DataBaseConfig context = new DataBaseConfig();

        public Produto BuscaProduto(int id)
        {
            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                connection.Open();
                var sql = "SELECT * FROM clientes WHERE Id = @Id";
                return connection.QueryFirstOrDefault<Produto>(sql, new { Id = id });
            }
        }

        public void CriarProduto(Produto produto)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(context.ConnectionString()))
            {
                string query = "INSERT INTO produtos(Nome, Descricao) VALUES (:Nome, :Descricao)";

                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("Nome", produto.Nome, DbType.String);
                parametros.Add("Descricao", produto.Descricao, DbType.String);

                connection.Execute(query, parametros);
            }
        }
    }
}
