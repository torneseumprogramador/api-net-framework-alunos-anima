using Negocio.Service;
using System.Web.Mvc;

namespace Reserva.Api.Controllers
{
    public class ProdutosVendaController : Controller
    {
        ProdutoVendaService produtoVendaService = new ProdutoVendaService();
        // GET: ProdutosVenda
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProdutosVenda/Details/5
        public ActionResult Details(int id)
        {
            var produtoVenda = produtoVendaService.BuscaProdutosVenda();
            return View();
        }

        // GET: ProdutosVenda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutosVenda/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosVenda/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProdutosVenda/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosVenda/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProdutosVenda/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
