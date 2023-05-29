using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IProdutoRepository
    {
        List<ProdutoDTO> BuscarProdutos();
        ProdutoDTO BuscarProduto(int id);
        bool InserirProduto(ProdutoDTO produto);
        bool AtualizarProduto(int id, ProdutoDTO produto);
        bool DeletarProduto(int id);
    }
}
