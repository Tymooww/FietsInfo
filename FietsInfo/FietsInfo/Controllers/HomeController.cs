using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FietsInfo.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseModel db = new DatabaseModel();

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

        public ActionResult Login_Click(string gebruikersnaam, string wachtwoord)
        {
            //Session["gebruikersnaam"] = gebruikersnaam;
            ACCOUNT account = db.ACCOUNT.Find(gebruikersnaam);
            //if (account.gebruikersnaam)

            return RedirectToAction("Index");
        }
        
        public ActionResult Registreer_Click(string gebruikersnaam, string wachtwoord, string voornaam, int binnenbeenlengte)
        {
            //Random nummer genereren voor UserID
            Random RandomNummer = new Random();
            int nummer = RandomNummer.Next();
            
            //Aanmaken van een account in een object
            ACCOUNT niewAccount = new ACCOUNT()
            {
                Gebruikersnaam = gebruikersnaam,
                UserID = nummer,
                Wachtwoord = wachtwoord,
                Binnenbeenlengte = binnenbeenlengte,
                Voornaam = voornaam,
                Leeftijd = null,
                IsAdmin = false,
                Gewicht = null,
                Lengte = null,
                Niveau = 0
            };

            //Account toevoegen aan database
            db.ACCOUNT.Add(niewAccount);
            db.SaveChanges();

            return RedirectToAction("Login");
        }
    }
}