using Dapper;
using Data.Context;
using Data.Model;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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
                var sql = "SELECT * FROM produtos WHERE Id = @Id";
                return connection.QueryFirstOrDefault<Produto>(sql, new { Id = id });
            }
        }

        public List<Produto> BuscaProdutos()
        {
            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                connection.Open();
                var sql = "SELECT * FROM produtos";
                return connection.Query<Produto>(sql).ToList();
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

        public void DeletaProduto(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(context.ConnectionString()))
            {
                string query = "DELETE FROM produtos WHERE Id = :Id";

                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("Id", id, DbType.Int32);

                connection.Execute(query, parametros);
            }
        }

        public void AtualizaProduto(Produto produto)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(context.ConnectionString()))
            {
                string query = "UPDATE PRODUTOS " +
                    "set Nome = @Nome, Descricao = @Descricao " +
                    "WHERE Id = @Id";

                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("Id", produto.Id, DbType.Int32);
                parametros.Add("Nome", produto.Nome, DbType.String);
                parametros.Add("Descricao", produto.Descricao, DbType.String);

                connection.Execute(query, parametros);
            }
        }
    }
}
