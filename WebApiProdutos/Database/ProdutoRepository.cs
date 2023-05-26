using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ProdutoRepository : BaseRepository
    {
        public IEnumerable<T> BuscarListaProdutos<T>()
        {
            string sql = @"SELECT * FROM produto";

            return BuscarLista<T>(sql);
        }

        public T BuscarProduto<T, R>(R argument)
        {
            string sql = $"SELECT id, nome, descricao FROM produto WHERE id = { argument }";

            return BuscarValor<T, R>(sql, argument);
        }
    }
}
