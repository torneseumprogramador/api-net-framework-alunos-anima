using Data.Model;
using Data.Repository;

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
    }
}
