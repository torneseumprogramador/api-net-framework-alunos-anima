using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Execricio.NETFramework.CRUD.Database.Repository.Interfaces
{
    public interface IBaseRepository : IDisposable
    {
        IDbConnection GetConnection();
        bool GetStatusConnection();
        bool Salvar(object entity);
        IEnumerable<object> Recuperar();
        object Recuperar(int id);
        bool Atualizar(object entity);
        bool Deletar(int id);
    }
}

