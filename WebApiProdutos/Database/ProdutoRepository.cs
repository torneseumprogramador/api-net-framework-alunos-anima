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
            string sql = @"SELECT id, nome, descricao FROM produto WHERE id = @id";

            return BuscarValor<T, R>(sql, id);
        }

        public void SalvarProduto<T, R>(R produto)
        {
            string sql = @"INSERT INTO produto (nome, descricao)
                                        VALUES (@nome, @descricao)";

            SalvarValor<T, R>(sql, produto);            
        }        
    }
}
