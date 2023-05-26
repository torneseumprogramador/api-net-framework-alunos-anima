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
        bool SalvarPreco(PrecoArgument preco);
        bool AtualizarPreco(PrecoArgument preco);
        bool DeletarPreco(int id);
        IEnumerable<PrecoArgument> RecuperarPrecos();
        PrecoArgument RecuperarPreco(int id);
    }
}
