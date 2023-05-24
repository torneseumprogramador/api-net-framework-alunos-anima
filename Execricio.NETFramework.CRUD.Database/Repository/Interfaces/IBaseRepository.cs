using System;
using System.Collections.Generic;

namespace Execricio.NETFramework.CRUD.Database.Repository.Interfaces
{
    /// <summary>
    /// Interface para o repositório base que define operações básicas de CRUD.
    /// </summary>
    /// <typeparam name="T">O tipo de entidade manipulada pelo repositório.</typeparam>
    public interface IBaseRepository<T> : IDisposable
    {
        /// <summary>
        /// Salva uma entidade.
        /// </summary>
        /// <param name="entity">A entidade a ser salva.</param>
        /// <returns>True se a entidade foi salva com sucesso, False caso contrário.</returns>
        bool Salvar(T entity);

        /// <summary>
        /// Recupera todas as entidades.
        /// </summary>
        /// <returns>Uma coleção de entidades.</returns>
        IEnumerable<T> Recuperar();

        /// <summary>
        /// Recupera uma entidade pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da entidade a ser recuperada.</param>
        /// <returns>A entidade encontrada ou null se não encontrada.</returns>
        T Recuperar(int id);

        /// <summary>
        /// Atualiza uma entidade.
        /// </summary>
        /// <param name="entity">A entidade a ser atualizada.</param>
        /// <returns>True se a entidade foi atualizada com sucesso, False caso contrário.</returns>
        bool Atualizar(T entity);

        /// <summary>
        /// Deleta uma entidade pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da entidade a ser deletada.</param>
        /// <returns>True se a entidade foi deletada com sucesso, False caso contrário.</returns>
        bool Deletar(int id);
    }
}
