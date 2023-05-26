using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiProdutos.Models.Interface
{
    public interface IProdutoModel
    {
        IEnumerable<ProdutoModel> BuscarListaProdutos();
        ProdutoModel BuscarProduto(int produtoId);
        void SalvarProduto(ProdutoModel produto);
    }
}
