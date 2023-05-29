using Dapper;
using Data.Context;
using Data.Model;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repository
{
    public class ProdutoVendaRepository
    {
        public DataBaseConfig context = new DataBaseConfig();

        public List<ProdutoVenda> BuscaProdutosVenda()
        {
            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                connection.Open();
                var sql = "SELECT pt.Nome, " +
                    "pt.Descricao," +
                    "pc.Valor," +
                    "pc.data_preco" +
                    " FROM produtos pt " +
                    "join precos pc on pt.id = pc.produto_id";

                return connection.Query<ProdutoVenda>(sql).ToList();
            }
        }

        public ProdutoVenda BuscaProdutosVendaPorId(int id)
        {
            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                connection.Open();
                var sql = "SELECT pt.Nome, " +
                    "pt.Descricao," +
                    "pc.Valor," +
                    "pc.data_preco" +
                    " FROM produtos pt " +
                    "join precos pc on pt.id = pc.produto_id " +
                    "where pt.Id = @Id";

                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("Id", id, DbType.Int32);

                return connection.QueryFirst<ProdutoVenda>(sql, parametros);
            }
        }
    }
}
