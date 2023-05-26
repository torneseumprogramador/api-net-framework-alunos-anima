using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IPrecoRepository
    {
        List<PrecoDTO> BuscarPrecos();
        PrecoDTO BuscarPreco(int id);
        bool InserirPreco(PrecoDTO preco);
        bool AtualizarPreco(int id, PrecoDTO preco);
        bool DeletarPreco(int id);
    }
}
