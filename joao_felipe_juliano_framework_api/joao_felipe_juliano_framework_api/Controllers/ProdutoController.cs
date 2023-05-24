using System.Linq;
using System.Web.Http;

namespace joao_felipe_juliano_framework_api.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        private readonly MeuContexto _context;

        public ProdutoController()
        {
            _context = new MeuContexto();
        }

        [System.Web.Mvc.HttpGet]
        public IHttpActionResult Get()
        {
            // Exemplo de consulta ao banco de dados
            var produtos = _context.Produtos.ToList();

            // Processar os dados retornados

            return Ok(produtos);
        }
    }
}
