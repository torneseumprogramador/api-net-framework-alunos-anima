using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        public void SalvarProduto<T, R>(R produto)
        {
            string sql = @"INSERT INTO produto (nome, descricao)
                                        VALUES (@nome, @descricao)";

            SalvarValor<T, R>(sql, produto);
        }

        public void EditarProduto<T, R>(R produto)
        {
            string sql = @"UPDATE produto
                              SET nome = @nome, descricao = @descricao
                            WHERE id = @id";

            EditarValor<T, R>(sql, produto);
        }

        public void DeletarProduto(int id)
        {
            string sql = $"DELETE FROM produto WHERE id = {id}";

            DeletarValor(sql);
        }
    }
}
