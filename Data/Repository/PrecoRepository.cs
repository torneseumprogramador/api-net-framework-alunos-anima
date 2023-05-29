using Dapper;
using Data.Context;
using Data.Model;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repository
{
    public class PrecoRepository
    {
        public DataBaseConfig context = new DataBaseConfig();
        public Preco BuscaPreco(int id)
        {
            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                connection.Open();
                var sql = "SELECT * FROM precos WHERE Id = @Id";
                return connection.QueryFirstOrDefault<Preco>(sql, new { Id = id });
            }
        }

        public Preco BuscaPrecoPorIdProduto(int id)
        {
            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                connection.Open();
                var sql = "SELECT * FROM precos WHERE Id_produto = @IdProduto";

                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("IdProduto", id, DbType.Int32);

                return connection.QueryFirstOrDefault<Preco>(sql, parametros);
            }
        }

        public void CriarPreco(Preco preco)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(context.ConnectionString()))
            {
                string query = "INSERT INTO precos(Id_Produto, Data_preco) VALUES (:IdProduto, :DataPreco)";

                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("IdProduto", preco.Id_Produto, DbType.Int32);
                parametros.Add("DataPreco", preco.Data_Preco, DbType.DateTime);

                connection.Execute(query, parametros);
            }
        }

        public List<Preco> BuscaPrecos()
        {
            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                connection.Open();
                var sql = "SELECT * FROM precos ";
                return connection.Query<Preco>(sql).ToList();
            }
        }

        public void DeletaPreco(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(context.ConnectionString()))
            {
                string query = "DELETE FROM precos WHERE Id = :Id";

                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("Id", id, DbType.Int32);

                connection.Execute(query, parametros);
            }
        }
    }
}
