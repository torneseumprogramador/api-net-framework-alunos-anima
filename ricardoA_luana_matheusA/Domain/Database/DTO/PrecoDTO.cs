using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class PrecoDTO
    {
        public int Id { get; set; }
        public string ProdutoId { get; set; }
        public double Preco { get; set; }
        public DateTime Data { get; set; }

    }
}
