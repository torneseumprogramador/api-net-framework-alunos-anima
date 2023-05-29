using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace joao_felipe_juliano_framework_api.Models
{
    public class Preco
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public float Valor { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}