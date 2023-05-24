using System.Collections.Generic;

namespace Execricio.NETFramework.CRUD.Business.Services.Interfaces
{
    public interface IBaseService<T>
    {
        IEnumerable<T> Recuperar();
        T Recuperar(int id);
        bool Salvar(T produto);
        bool Atualizar(T produto);
        bool Deletar(int id);
    }
}
