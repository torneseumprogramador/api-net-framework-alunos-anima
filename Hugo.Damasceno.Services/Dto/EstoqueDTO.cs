using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo.Damasceno.Services.Dto
{
    public class EstoqueDTO
    {
        public string Id { get; set; }
        public string ProdutoId { get; set; }
        public string Preco { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
    }
}
