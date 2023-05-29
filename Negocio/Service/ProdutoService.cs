using Data.Model;
using Data.Repository;
using System.Collections.Generic;

namespace Negocio.Service
{
    public class ProdutoService
    {
        public ProdutoService()
        {

        }

        public ProdutoRepository produtoRepository = new ProdutoRepository();

        public void CriarProduto(Produto produto)
        {
            produtoRepository.CriarProduto(produto);
        }

        public Produto BuscaProduto(int id)
        {
            return produtoRepository.BuscaProduto(id);
        }

        public List<Produto> BuscaProdutos()
        {
            return produtoRepository.BuscaProdutos();
        }

        public void DeletaProduto(int id)
        {
            produtoRepository.DeletaProduto(id);
        }
        public void AtualizaProduto(Produto produto)
        {
            produtoRepository.AtualizaProduto(produto);
        }
    }
}
