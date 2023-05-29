using System;

namespace Reserva.Api.Models
{
    public class PrecoDTO
    {
        public int Id{ get; set; }
        public int Id_Produto { get; set; }
        public DateTime Data_Preco { get; set; }
    }
}