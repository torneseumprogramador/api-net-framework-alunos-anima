using Service.DTO;
using System.Collections.Generic;

namespace Service.Services.Interfaces
{
    public interface IProdutoService
    {
        List<ProdutoDTO> BuscarProdutos();
        ProdutoDTO BuscarProduto(int id);
        bool InserirProduto(ProdutoDTO produto);
        bool AtualizarProduto(int id, ProdutoDTO produto);
        bool DeletarProduto(int id);

    }
}