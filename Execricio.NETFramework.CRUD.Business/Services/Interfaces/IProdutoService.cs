using Execricio.NETFramework.CRUD.Business.Requests;
using Execricio.NETFramework.CRUD.Business.Responses;
using System.Collections.Generic;

namespace Execricio.NETFramework.CRUD.Business.Services.Interfaces
{
    /// <summary>
    /// Interface para gerenciamento de produtos.
    /// </summary>
    public interface IProdutoService
    {
        /// <summary>
        /// Salva um produto.
        /// </summary>
        /// <param name="produto">O produto a ser salvo.</param>
        /// <returns>True se o produto foi salvo com sucesso; caso contrário, false.</returns>
        bool SalvarProduto(ProdutoRequest produto);

        /// <summary>
        /// Atualiza um produto.
        /// </summary>
        /// <param name="id">O ID do produto a ser atualizado.</param>
        /// <param name="produto">O produto atualizado.</param>
        /// <returns>True se o produto foi atualizado com sucesso; caso contrário, false.</returns>
        bool AtualizarProduto(int id, ProdutoRequest produto);

        /// <summary>
        /// Deleta um produto.
        /// </summary>
        /// <param name="id">O ID do produto a ser deletado.</param>
        /// <returns>True se o produto foi deletado com sucesso; caso contrário, false.</returns>
        bool DeletarProduto(int id);

        /// <summary>
        /// Recupera um produto.
        /// </summary>
        /// <param name="id">O ID do produto a ser recuperado.</param>
        /// <param name="infoPreco">Indica se as informações de preço devem ser retornadas (opcional).</param>
        /// <returns>Um objeto ProdutoResponse que representa o produto recuperado.</returns>
        ProdutoResponse RecuperarProduto(int id, bool infoPreco = false);

        /// <summary>
        /// Recupera uma lista de produtos.
        /// </summary>
        /// <param name="infoPreco">Indica se as informações de preço devem ser retornadas (opcional).</param>
        /// <returns>Uma coleção de objetos ProdutoResponse que representam os produtos recuperados.</returns>
        IEnumerable<ProdutoResponse> RecuperarProdutos(bool infoPreco = false);
    }

}
