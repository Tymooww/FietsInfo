using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FietsInfo;

namespace FietsInfo.Controllers
{
    public class INGESCHREVENSCHEMAsController : Controller
    {
        private DatabaseModel db = new DatabaseModel();

        // GET: INGESCHREVENSCHEMAs
        public ActionResult Index()
        {
            //Check of gebruiker is ingelogd
            if (string.IsNullOrWhiteSpace((string)Session["Gebruikersnaam"]))
            {
                return RedirectToAction("Login", "Home");
            }

            string gebruikersnaam = (string)Session["Gebruikersnaam"];
            var iNGESCHREVENSCHEMA = db.INGESCHREVENSCHEMA.Include(i => i.ACCOUNT).Include(i => i.TRAININGSSCHEMA).Where(a => a.Gebruikersnaam == gebruikersnaam);
            return View(iNGESCHREVENSCHEMA.ToList());
        }

        // GET: INGESCHREVENSCHEMAs/Details/5
        public ActionResult Details(string gebruikersnaam, string trainingsnaam)
        {
            if (gebruikersnaam == null || trainingsnaam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INGESCHREVENSCHEMA iNGESCHREVENSCHEMA = db.INGESCHREVENSCHEMA.Find(gebruikersnaam, trainingsnaam);
            if (iNGESCHREVENSCHEMA == null)
            {
                return HttpNotFound();
            }
            return View(iNGESCHREVENSCHEMA);
        }

        // GET: INGESCHREVENSCHEMAs/Create
        public ActionResult Create()
        {
            ViewBag.Gebruikersnaam = new SelectList(db.ACCOUNT, "Gebruikersnaam", "Wachtwoord");
            ViewBag.Trainingsnaam = new SelectList(db.TRAININGSSCHEMA, "Trainingsnaam", "Omschrijving");
            return View();
        }

        // POST: INGESCHREVENSCHEMAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Gebruikersnaam,Trainingsnaam,IsVoltooid,DagenVoltooid")] INGESCHREVENSCHEMA iNGESCHREVENSCHEMA)
        {
            if (ModelState.IsValid)
            {
                db.INGESCHREVENSCHEMA.Add(iNGESCHREVENSCHEMA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Gebruikersnaam = new SelectList(db.ACCOUNT, "Gebruikersnaam", "Wachtwoord", iNGESCHREVENSCHEMA.Gebruikersnaam);
            ViewBag.Trainingsnaam = new SelectList(db.TRAININGSSCHEMA, "Trainingsnaam", "Omschrijving", iNGESCHREVENSCHEMA.Trainingsnaam);
            return View(iNGESCHREVENSCHEMA);
        }

        // GET: INGESCHREVENSCHEMAs/Edit/5
        public ActionResult Edit(string gebruikersnaam, string trainingsnaam)
        {
            if (gebruikersnaam == null || trainingsnaam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INGESCHREVENSCHEMA iNGESCHREVENSCHEMA = db.INGESCHREVENSCHEMA.Find(gebruikersnaam, trainingsnaam);
            if (iNGESCHREVENSCHEMA == null)
            {
                return HttpNotFound();
            }
            ViewBag.Gebruikersnaam = new SelectList(db.ACCOUNT, "Gebruikersnaam", "Wachtwoord", iNGESCHREVENSCHEMA.Gebruikersnaam);
            ViewBag.Trainingsnaam = new SelectList(db.TRAININGSSCHEMA, "Trainingsnaam", "Omschrijving", iNGESCHREVENSCHEMA.Trainingsnaam);
            return View(iNGESCHREVENSCHEMA);
        }

        // POST: INGESCHREVENSCHEMAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Gebruikersnaam,Trainingsnaam,IsVoltooid,DagenVoltooid")] INGESCHREVENSCHEMA iNGESCHREVENSCHEMA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNGESCHREVENSCHEMA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Gebruikersnaam = new SelectList(db.ACCOUNT, "Gebruikersnaam", "Wachtwoord", iNGESCHREVENSCHEMA.Gebruikersnaam);
            ViewBag.Trainingsnaam = new SelectList(db.TRAININGSSCHEMA, "Trainingsnaam", "Omschrijving", iNGESCHREVENSCHEMA.Trainingsnaam);
            return View(iNGESCHREVENSCHEMA);
        }

        // GET: INGESCHREVENSCHEMAs/Delete/5
        public ActionResult Delete(string gebruikersnaam, string trainingsnaam)
        {
            if (gebruikersnaam == null || trainingsnaam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INGESCHREVENSCHEMA iNGESCHREVENSCHEMA = db.INGESCHREVENSCHEMA.Find(gebruikersnaam, trainingsnaam);
            if (iNGESCHREVENSCHEMA == null)
            {
                return HttpNotFound();
            }
            return View(iNGESCHREVENSCHEMA);
        }

        // POST: INGESCHREVENSCHEMAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string gebruikersnaam, string trainingsnaam)
        {
            INGESCHREVENSCHEMA iNGESCHREVENSCHEMA = db.INGESCHREVENSCHEMA.Find(gebruikersnaam, trainingsnaam);
            db.INGESCHREVENSCHEMA.Remove(iNGESCHREVENSCHEMA);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
