using Data.Model;
using Negocio.Service;
using Reserva.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Reserva.Api.Controllers
{
    public class ProdutosController : Controller
    {
        ProdutoService produtoService = new ProdutoService();
        // GET: Produtos
        public ActionResult Index()
        {
            var produtos = produtoService.BuscaProdutos();

            var produtosDto = new List<ProdutoDTO>();

            foreach (var p in produtos)
            {
                produtosDto.Add(new ProdutoDTO { Id = p.Id, Descricao = p.Descricao, Nome = p.Nome });
            }
            return View(produtosDto);
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        public ActionResult Create(ProdutoDTO produtoDto)
        {
            try
            {
                var produto = new Produto
                {
                    Nome = produtoDto.Nome,
                    Descricao = produtoDto.Descricao,
                };

                produtoService.CriarProduto(produto);
                // TODO: Add insert logic here
                var resposta = new
                {
                    Success = true,
                    Message = "Produto criado com sucesso",
                    Data = produtoDto
                };
                Redirect("Index");

                return Json(resposta, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = produtoService.BuscaProduto(id);
            var produtoDto = new ProdutoDTO
            {
                Id = id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
            };
            return View(produtoDto);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        public ActionResult Edit(ProdutoDTO produtoDTO)
        {
            try
            {
                var produto = new Produto
                {
                    Id = produtoDTO.Id,
                    Nome = produtoDTO.Nome,
                    Descricao = produtoDTO.Descricao,
                };
                produtoService.AtualizaProduto(produto);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produtos/Delete/5
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
