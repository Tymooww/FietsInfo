using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

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
            if (string.IsNullOrWhiteSpace(wachtwoord))
            {

            }

            else
            {
                ACCOUNT account = db.ACCOUNT.Find(gebruikersnaam);
                if (account.Gebruikersnaam == gebruikersnaam && account.Wachtwoord == wachtwoord)
                {
                    HttpContext.Session.Add("Gebruikersnaam", gebruikersnaam);
                    Debug.WriteLine(Session["Gebruikersnaam"]);
                    return RedirectToAction("Index");
                }
                
                //Toon foutmelding
                
            }
           
            return RedirectToAction("Inloggen");
        }
        
        public ActionResult Registreer_Click(string gebruikersnaam, string wachtwoord, string voornaam, int? binnenbeenlengte)
        {
            if (string.IsNullOrWhiteSpace(gebruikersnaam) || string.IsNullOrWhiteSpace(wachtwoord) || string.IsNullOrWhiteSpace(voornaam) || binnenbeenlengte == null)
            {
                //Toon foutmelding
                return RedirectToAction("Registreer");
            }
            else
            {
                int binnenbeenlengteInt = binnenbeenlengte.GetValueOrDefault();

                //Aanmaken van een account in een object
                ACCOUNT niewAccount = new ACCOUNT()
                {
                    Gebruikersnaam = gebruikersnaam,
                    Wachtwoord = wachtwoord,
                    Binnenbeenlengte = binnenbeenlengteInt,
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
}