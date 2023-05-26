using Entidades;
using Negocios;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;

namespace AndersonCairoGabriel.Controllers
{
    public class PrecoProdutoController : ApiController
    {
        private readonly Produtos _produtosBusiness;

        public PrecoProdutoController()
        {
            _produtosBusiness = new Produtos();
        }
    }
}