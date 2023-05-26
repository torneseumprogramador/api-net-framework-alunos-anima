using Execricio.NETFramework.CRUD.Business.Requests;
using Execricio.NETFramework.CRUD.Business.Responses;
using System.Collections.Generic;

namespace Execricio.NETFramework.CRUD.Business.Services.Interfaces
{
    public interface IProdutoService
    {
        bool SalvarProduto(ProdutoRequest produto);
        bool AtualizarProduto(int id, ProdutoRequest produto);
        bool DeletarProduto(int id);
        ProdutoResponse RecuperarProduto(int id);
        IEnumerable<ProdutoResponse> RecuperarProdutos();
    }
}
