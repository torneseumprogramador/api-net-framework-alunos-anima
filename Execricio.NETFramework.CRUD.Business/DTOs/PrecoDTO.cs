using System;

namespace Execricio.NETFramework.CRUD.Business.DTOs
{
    public class PrecoDTO
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public decimal Preco { get; set; }
        public DateTime Data { get; set; }
    }
}
