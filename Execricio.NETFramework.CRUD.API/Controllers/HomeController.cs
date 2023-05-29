using System.Web.Mvc;

namespace Execricio.NETFramework.CRUD.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
