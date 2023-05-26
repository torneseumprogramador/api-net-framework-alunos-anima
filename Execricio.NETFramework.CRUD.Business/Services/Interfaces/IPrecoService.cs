using Execricio.NETFramework.CRUD.Business.Requests;
using Execricio.NETFramework.CRUD.Business.Responses;
using System.Collections.Generic;

namespace Execricio.NETFramework.CRUD.Business.Services.Interfaces
{
    /// <summary>
    /// Interface para gerenciamento de preços.
    /// </summary>
    public interface IPrecoService
    {
        /// <summary>
        /// Salva um preço.
        /// </summary>
        /// <param name="preco">O preço a ser salvo.</param>
        /// <returns>True se o preço foi salvo com sucesso; caso contrário, false.</returns>
        bool SalvarPreco(PrecoRequest preco);

        /// <summary>
        /// Atualiza um preço.
        /// </summary>
        /// <param name="id">O ID do preço a ser atualizado.</param>
        /// <param name="preco">O preço atualizado.</param>
        /// <returns>True se o preço foi atualizado com sucesso; caso contrário, false.</returns>
        bool AtualizarPreco(int id, PrecoRequest preco);

        /// <summary>
        /// Deleta um preço.
        /// </summary>
        /// <param name="id">O ID do preço a ser deletado.</param>
        /// <returns>True se o preço foi deletado com sucesso; caso contrário, false.</returns>
        bool DeletarPreco(int id);

        /// <summary>
        /// Recupera um preço.
        /// </summary>
        /// <param name="id">O ID do preço a ser recuperado.</param>
        /// <returns>Um objeto PrecoResponse que representa o preço recuperado.</returns>
        PrecoResponse RecuperarPreco(int id);

        /// <summary>
        /// Recupera uma lista de preços.
        /// </summary>
        /// <returns>Uma coleção de objetos PrecoResponse que representam os preços recuperados.</returns>
        IEnumerable<PrecoResponse> RecuperarPrecos();
    }
}
