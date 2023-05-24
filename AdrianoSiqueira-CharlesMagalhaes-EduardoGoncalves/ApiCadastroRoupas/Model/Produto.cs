using ApiCadastroRoupas.Connection;
using Dapper;
using System.Data;

namespace ApiCadastroRoupas.Model
{
    public class Produto : PgsqlBaseRepository
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public double Preco { get; set; }
        public DateTime Data { get; set; }

        private readonly BaseConnection _baseConnection;

        public Produto(ILogger<Produto> logger) : base(logger)
        {
        }

        public async Task<IEnumerable<Produto>> Produtos()
        {
            string sql = @"SELECT * FROM PRODUTO";

            IDbConnection cnn = GetConnection();

            return await cnn.QueryAsync<Produto>(sql);
        }
    }
}