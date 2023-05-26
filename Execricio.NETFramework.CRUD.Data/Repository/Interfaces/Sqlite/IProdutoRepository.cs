using Execricio.NETFramework.CRUD.Data.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Execricio.NETFramework.CRUD.Data.Repository.Interfaces.Sqlite
{
    public interface IProdutoRepository
    {
        /// <summary>
        /// Salva um produto.
        /// </summary>
        /// <param name="produto">O produto a ser salvo.</param>
        /// <returns>True se o produto foi salvo com sucesso; caso contrário, false.</returns>
        bool SalvarProduto(ProdutoArgument produto);

        /// <summary>
        /// Atualiza um produto.
        /// </summary>
        /// <param name="produto">O produto a ser atualizado.</param>
        /// <returns>True se o produto foi atualizado com sucesso; caso contrário, false.</returns>
        bool AtualizarProduto(ProdutoArgument produto);

        /// <summary>
        /// Deleta um produto.
        /// </summary>
        /// <param name="id">O ID do produto a ser deletado.</param>
        /// <returns>True se o produto foi deletado com sucesso; caso contrário, false.</returns>
        bool DeletarProduto(int id);

        /// <summary>
        /// Recupera um produto pelo ID.
        /// </summary>
        /// <param name="id">O ID do produto a ser recuperado.</param>
        /// <returns>Um objeto ProdutoArgument que representa o produto recuperado.</returns>
        ProdutoArgument RecuperarProduto(int id);

        /// <summary>
        /// Recupera todos os produtos.
        /// </summary>
        /// <returns>Uma coleção de objetos ProdutoArgument que representam os produtos recuperados.</returns>
        IEnumerable<ProdutoArgument> RecuperarProdutos();
    }
}
