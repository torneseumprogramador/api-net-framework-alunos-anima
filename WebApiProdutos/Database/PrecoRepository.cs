using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class PrecoRepository : BaseRepository
    {
        public IEnumerable<T> BuscarListaPrecos<T>()
        {
            string sql = @"SELECT id, produto_id, preco_produto, data FROM preco";

            return BuscarLista<T>(sql);
        }

        public T BuscarPreco<T, R>(R id)
        {
            string sql = $"SELECT id, produto_id, preco_produto, data FROM preco WHERE id = {id}";

            return BuscarValor<T>(sql);
        }

        public HttpResponseMessage SalvarPreco<T, R>(R preco)
        {
            string sql = @"INSERT INTO preco(produto_id, preco_produto, data) 
                                VALUES (@produtoId, @precoProduto, CURRENT_TIMESTAMP);";

            return SalvarValor<T, R>(sql, preco);
        }

        public HttpResponseMessage EditarPreco<T, R>(R preco)
        {
            string sql = @"UPDATE preco
                              SET preco_produto = @precoProduto
                            WHERE id = @id";

            return SalvarValor<T, R>(sql, preco);
        }

        public HttpResponseMessage DeletarPreco(int id)
        {
            string sql = $"DELETE FROM preco WHERE id = {id}";

            return DeletarValor(sql);
        }
    }
}
