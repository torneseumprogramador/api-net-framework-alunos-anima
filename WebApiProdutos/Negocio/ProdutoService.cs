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

        public T BuscaProduto<T, R>(R id)
        {
            return produtoRepository.BuscarProduto<T, R>(id);
        }

        public void SalvarProduto<T, R>(R produto)
        {
            produtoRepository.SalvarProduto<T, R>(produto);
        }

        public void EditarProduto<T, R>(R produto)
        {
            produtoRepository.EditarProduto<T, R>(produto);
        }

        public void DeletarProduto(int id)
        {
            produtoRepository.DeletarProduto(id);
        }
    }
}