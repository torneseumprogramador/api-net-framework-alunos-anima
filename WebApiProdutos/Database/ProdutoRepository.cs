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
    public class ProdutoRepository : BaseRepository
    {
        public IEnumerable<T> BuscarListaProdutos<T>()
        {
            string sql = @"SELECT id, nome, descricao FROM produto";

            return BuscarLista<T>(sql);
        }

        public T BuscarProduto<T, R>(R id)
        {
            string sql = $"SELECT id, nome, descricao FROM produto WHERE id = {id}";

            return BuscarValor<T>(sql);
        }

        public HttpResponseMessage SalvarProduto<T, R>(R produto)
        {
            string sql = @"INSERT INTO produto (nome, descricao)
                                        VALUES (@nome, @descricao)";

            return SalvarValor<T, R>(sql, produto);
        }

        public HttpResponseMessage EditarProduto<T, R>(R produto)
        {
            string sql = @"UPDATE produto
                              SET nome = COALESCE(?, @nome), descricao = COALESCE(?, @descricao)
                            WHERE id = @id";

            return SalvarValor<T, R>(sql, produto);
        }

        public HttpResponseMessage DeletarProduto(int id)
        {
            string sql = $"DELETE FROM produto WHERE id = {id}";

            return DeletarValor(sql);
        }
    }
}
