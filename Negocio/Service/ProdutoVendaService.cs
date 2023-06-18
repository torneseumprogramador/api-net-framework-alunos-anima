using Data.Model;
using Data.Repository;
using System.Collections.Generic;

namespace Negocio.Service
{
    public class ProdutoVendaService
    {
        ProdutoVendaRepository produtoVendaRepository = new ProdutoVendaRepository();

        public List<ProdutoVenda> BuscaProdutosVenda()
        {
            return produtoVendaRepository.BuscaProdutosVenda();
        }

        public ProdutoVenda BuscaProdutoVendaPorId(int Id)
        {
            return produtoVendaRepository.BuscaProdutosVendaPorId(Id);
        }
    }
}
