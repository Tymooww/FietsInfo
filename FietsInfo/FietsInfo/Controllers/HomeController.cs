using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FietsInfo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }
        
        public ActionResult Registreer()
        {
            return View();
        }

        public ActionResult Login_Click()
        {
            //Login

            return RedirectToAction("Index");
        }
        
        public ActionResult Registreer_Click()
        {
            //Opslaan in db

            return RedirectToAction("Login");
        }
    }
}