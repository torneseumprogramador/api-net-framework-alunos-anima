using Execricio.NETFramework.CRUD.Data.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Execricio.NETFramework.CRUD.Data.Repository.Interfaces.Sqlite
{
    public interface IPrecoRepository
    {
        /// <summary>
        /// Salva um preço.
        /// </summary>
        /// <param name="preco">O preço a ser salvo.</param>
        /// <returns>True se o preço foi salvo com sucesso; caso contrário, false.</returns>
        bool SalvarPreco(PrecoArgument preco);

        /// <summary>
        /// Atualiza um preço.
        /// </summary>
        /// <param name="preco">O preço a ser atualizado.</param>
        /// <returns>True se o preço foi atualizado com sucesso; caso contrário, false.</returns>
        bool AtualizarPreco(PrecoArgument preco);

        /// <summary>
        /// Deleta um preço.
        /// </summary>
        /// <param name="id">O ID do preço a ser deletado.</param>
        /// <returns>True se o preço foi deletado com sucesso; caso contrário, false.</returns>
        bool DeletarPreco(int id);

        /// <summary>
        /// Recupera todos os preços.
        /// </summary>
        /// <returns>Uma coleção de objetos PrecoArgument que representam os preços recuperados.</returns>
        IEnumerable<PrecoArgument> RecuperarPrecos();

        /// <summary>
        /// Recupera um preço pelo ID.
        /// </summary>
        /// <param name="id">O ID do preço a ser recuperado.</param>
        /// <returns>Um objeto PrecoArgument que representa o preço recuperado.</returns>
        PrecoArgument RecuperarPreco(int id);
    }
}
