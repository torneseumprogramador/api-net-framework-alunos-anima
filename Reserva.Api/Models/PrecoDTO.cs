using System;

namespace Reserva.Api.Models
{
    public class PrecoDTO
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public int Produto_id { get; set; }
        public DateTime Data_Preco { get; set; }
    }
}