using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProdutoService
    {
        ProdutoRepository produtoRepository = new ProdutoRepository();

        public IEnumerable<T> BuscarListaProdutos<T>()
        {
            return produtoRepository.BuscarListaProdutos<T>();
        }

        public T BuscaProduto<T, R>(R argument)
        {
            return produtoRepository.BuscarProduto<T, R>(argument);
        }
    }
}