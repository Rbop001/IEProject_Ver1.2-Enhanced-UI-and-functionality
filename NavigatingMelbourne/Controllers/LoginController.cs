using NavigatingMelbourne.Models;
using System;
using System.Web.Mvc;


namespace NavigatingMelbourne.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string name, string password)
        {
            if("admin".Equals(name) && "TP22@1993".Equals(password))
            {
                Session["user"] = new User() { Login = name, Name = "admin" };
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}