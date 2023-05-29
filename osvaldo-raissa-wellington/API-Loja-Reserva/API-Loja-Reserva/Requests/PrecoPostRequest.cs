using API_Loja_Reserva.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Loja_Reserva.Requests
{
    public class PrecoPostRequest : PrecoModel
    {
        public int IdProduto { get;set;}
        [JsonIgnore]
        public override ProdutoModel Produto { get;set; }
    }
}