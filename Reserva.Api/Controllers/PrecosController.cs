using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reserva.Api.Controllers
{
    public class PrecosController : Controller
    {
        // GET: Precos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Precos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Precos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Precos/Create
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
