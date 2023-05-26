using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Execricio.NETFramework.CRUD.Data.DTOs
{
    public interface IPrecoDTO
    {
        int Id { get; set; }
        int ProdutoId { get; set; }
        decimal Preco { get; set; }
        string Data { get; set; }
        bool Ativo { get; set; }
    }
}
