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
        public ActionResult Vragenlijst()
        {
            return View();
        }
        public ActionResult Registreer()
        {
            return View();
        }

        public ActionResult Uitloggen()
        {
            Session["Gebruikersnaam"] = null;
            return View("Index");
        }

        public ActionResult Vragenlijst_Click(int? fietservaring, int? leeftijd, bool conditie, bool blessuregevoeligheid)
        {
            int niveaupunten = 0;
            if (fietservaring == null || leeftijd == null)
            {
                //Error melding geven
                HttpContext.Session.Add("VragenlijstCode", "VeldLeeg");
            }
            else
            {
                int leeftijdint = leeftijd.GetValueOrDefault();
                int fietservaringint = fietservaring.GetValueOrDefault();
                if (leeftijdint > 0 && leeftijdint <= 20)
                {
                    niveaupunten += 5;
                }
                if (leeftijdint > 20 && leeftijdint <= 40)
                {
                    niveaupunten += 4;
                }
                if (leeftijdint > 40 && leeftijdint <= 60)
                {
                    niveaupunten += 3;
                }
                if (leeftijdint > 60 && leeftijdint <= 80)
                {
                    niveaupunten += 2;
                }
                if (leeftijdint > 80)
                {
                    niveaupunten += 1;
                }
                if (fietservaringint == 0)
                {
                    niveaupunten += 1;
                }
                if (fietservaringint == 1)
                {
                    niveaupunten += 2;
                }
                if (fietservaringint == 3)
                {
                    niveaupunten += 3;
                }
                if (fietservaringint == 4)
                {
                    niveaupunten += 4;
                }
                if (fietservaringint > 5)
                {
                    niveaupunten += 5;
                }
                if (conditie == true)
                {
                    niveaupunten += 4;
                }
                if (conditie == false)
                {
                    niveaupunten += 2;
                }
                if (blessuregevoeligheid == true)
                {
                    niveaupunten += 1;
                }
                if (blessuregevoeligheid == false)
                {
                    niveaupunten += 3;
                }
                int niveau = niveaupunten / 4;
                Debug.WriteLine(niveau);

                ACCOUNT account = db.ACCOUNT.Find(Session["Registreergb"]);
                account.Niveau = niveau;
                db.SaveChanges();


            }
            return View("Login");
        }




        public ActionResult Login_Click(string gebruikersnaam, string wachtwoord)
        {
            if (string.IsNullOrWhiteSpace(gebruikersnaam) || string.IsNullOrWhiteSpace(wachtwoord))
            {
                //Error melding geven
                HttpContext.Session.Add("LoginCode", "VeldLeeg");
            }

            else
            {
                //Account zoeken
                ACCOUNT account = db.ACCOUNT.Find(gebruikersnaam);

                if (account != null)
                {
                    //Inloggegevens checken
                    if (account.Gebruikersnaam == gebruikersnaam && account.Wachtwoord == wachtwoord)
                    {
                        HttpContext.Session.Add("Gebruikersnaam", gebruikersnaam);
                        HttpContext.Session.Add("LoginCode", "Succes");
                        Debug.WriteLine(Session["Gebruikersnaam"] + " succesvol ingelogd!");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        //Error melding geven
                        HttpContext.Session.Add("LoginCode", "Onjuist");
                    }
                }
                else
                {
                    //Error melding geven
                    HttpContext.Session.Add("LoginCode", "Onjuist");
                }
            }
            return View("Login");
        }

        public ActionResult Registreer_Click(string gebruikersnaam, string wachtwoord, string voornaam, int? binnenbeenlengte)
        {
            if (string.IsNullOrWhiteSpace(gebruikersnaam) || string.IsNullOrWhiteSpace(wachtwoord) || string.IsNullOrWhiteSpace(voornaam) || binnenbeenlengte == null)
            {
                //Error melding geven
                HttpContext.Session.Add("RegistreerCode", "Onjuist");
                return RedirectToAction("Registreer");
            }
            else
            {
                int binnenbeenlengteInt = binnenbeenlengte.GetValueOrDefault();

                //Aanmaken van een account in een object
                ACCOUNT nieuwAccount = new ACCOUNT()
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

                //Account opslaan in de database
                db.ACCOUNT.Add(nieuwAccount);
                db.SaveChanges();
                HttpContext.Session.Add("Registreergb", gebruikersnaam);
                
                return RedirectToAction("Vragenlijst");
            }

        }
    }
}
