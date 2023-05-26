using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Execricio.NETFramework.CRUD.Data.DTOs
{
    public interface IProdutoDTO
    {
        int Id { get; set; }
        string Nome { get; set; }
        string Descricao { get; set; }
        decimal Preco { get; set; }
    }
}
