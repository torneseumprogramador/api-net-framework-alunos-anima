using Execricio.NETFramework.CRUD.Business.Requests;
using Execricio.NETFramework.CRUD.Business.Responses;
using System.Collections.Generic;

namespace Execricio.NETFramework.CRUD.Business.Services.Interfaces
{
    public interface IPrecoService
    {
        bool SalvarPreco(PrecoRequest preco);
        bool AtualizarPreco(int id, PrecoRequest preco);
        bool DeletarPreco(int id);
        PrecoResponse RecuperarPreco(int id);
        IEnumerable<PrecoResponse> RecuperarPrecos();
    }
}
