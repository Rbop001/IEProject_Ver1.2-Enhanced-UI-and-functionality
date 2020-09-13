using System.Web.Mvc;

namespace NavigatingMelbourne.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

    }
}