using Service.DTO;
using System.Collections.Generic;

namespace Service.Services.Interfaces
{
    public interface IPrecoService
    {
        List<PrecoDTO> BuscarPrecos();
        PrecoDTO BuscarPreco(int id);
        bool InserirPreco(PrecoDTO preco);
        bool AtualizarPreco(int id, PrecoDTO preco);
        bool DeletarPreco(int id);

    }
}