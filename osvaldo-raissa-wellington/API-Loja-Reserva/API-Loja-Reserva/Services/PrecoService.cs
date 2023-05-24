using API_Loja_Reserva.Models;
using API_Loja_Reserva.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Loja_Reserva.Services
{
    public class PrecoService
    {

        public static void AdicionarPreco(PrecoPostRequest request)
        {
            ProdutoModel produto = new ProdutoModel();
            produto.Id = request.IdProduto;

            PrecoModel preco = new PrecoModel{ 
                Data = request.Data,
                Preco = request.Preco,
                Produto = produto
            };

            preco.Adicionar();

        }
    }
}