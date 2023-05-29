using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Execricio.NETFramework.CRUD.Data.Repository.Interfaces
{
    /// <summary>
    /// Interface base para repositórios de dados.
    /// </summary>
    internal interface IBaseRepository
    {
        /// <summary>
        /// Obtém uma conexão com o banco de dados.
        /// </summary>
        /// <param name="open">Indica se a conexão deve ser aberta automaticamente (opcional).</param>
        /// <returns>Uma instância de IDbConnection que representa a conexão com o banco de dados.</returns>
        IDbConnection GetConnection(bool open = true);

        /// <summary>
        /// Obtém o status da conexão com o banco de dados.
        /// </summary>
        /// <returns>True se a conexão está aberta; caso contrário, false.</returns>
        bool GetStatusConnection();
    }
}
