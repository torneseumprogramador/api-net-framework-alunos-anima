using Execricio.NETFramework.CRUD.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Execricio.NETFramework.CRUD.Business.Requests
{
    public class PrecoRequest : IPrecoDTO
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public decimal Preco { get; set; }
        public string Data { get; set; }
        public bool Ativo { get; set; }
    }
}
