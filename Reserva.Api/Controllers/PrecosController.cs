using Data.Model;
using Negocio.Service;
using Reserva.Api.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Reserva.Api.Controllers
{
    public class PrecosController : Controller
    {
        PrecoService precoService = new PrecoService();
        ProdutoService produtoService = new ProdutoService();   
        // GET: Precos
        public ActionResult Index()
        {
            var precos = precoService.BuscaPrecos();
            var precosDto = new List<PrecoDTO>();

            foreach (var p in precos)
            {
                precosDto.Add(new PrecoDTO { Id = p.Id, Produto_id = p.Produto_id, Valor = p.Valor, Data_Preco = p.Data_Preco });
            }
            return View(precosDto);
        }

        // GET: Precos/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Precos/Create
        public ActionResult Create()
        {
            var produtos = produtoService.BuscaProdutos();
            ViewBag.Produtos = new SelectList(produtos, "Id", "Nome");
            return View();
        }

        // POST: Precos/Create
        [HttpPost]
        public ActionResult Create(PrecoDTO precoDTO)
        {
            try
            {
                var preco = new Preco
                {
                    Valor = precoDTO.Valor,
                    Produto_id = precoDTO.Produto_id
                };

                precoService.CriarPreco(preco);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Precos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Precos/Edit/5
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

        // GET: Precos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Precos/Delete/5
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
