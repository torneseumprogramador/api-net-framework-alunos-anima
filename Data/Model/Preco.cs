using System;

namespace Data.Model
{
    public class Preco
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public int Produto_id { get; set; }
        public DateTime Data_Preco { get; set; }
    }
}
