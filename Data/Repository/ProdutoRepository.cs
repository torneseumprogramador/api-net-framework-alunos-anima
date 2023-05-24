using Dapper;
using Data.Context;
using Data.Model;
using Npgsql;

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
    }
}
