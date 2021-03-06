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
    public class FIETSBENODIGDHEDENsController : Controller
    {
        private DatabaseModel db = new DatabaseModel();

        public ActionResult IndexAdmin()
        {
            //Check of gebruiker is ingelogd
            if (string.IsNullOrWhiteSpace((string)Session["Gebruikersnaam"]))
            {
                return RedirectToAction("Login", "Home");
            }
            //Check of gebruiker admin is
            if (db.ACCOUNT.Find((string)Session["Gebruikersnaam"]).IsAdmin)
            {
                var fIETSBENODIGDHEDEN = db.FIETSBENODIGDHEDEN.Include(f => f.ACCOUNT);
                return View(fIETSBENODIGDHEDEN.ToList());
            }

            return RedirectToAction("Login", "Home");
        }

        // GET: FIETSBENODIGDHEDENs
        public ActionResult Index()
        {
            var fIETSBENODIGDHEDEN = db.FIETSBENODIGDHEDEN.Include(f => f.ACCOUNT);
            return View(fIETSBENODIGDHEDEN.ToList());
        }

        // GET: FIETSBENODIGDHEDENs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FIETSBENODIGDHEDEN fIETSBENODIGDHEDEN = db.FIETSBENODIGDHEDEN.Find(id);
            if (fIETSBENODIGDHEDEN == null)
            {
                return HttpNotFound();
            }
            return View(fIETSBENODIGDHEDEN);
        }

        // GET: FIETSBENODIGDHEDENs/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.ACCOUNT, "Gebruikersnaam", "Wachtwoord");
            return View();
        }

        // POST: FIETSBENODIGDHEDENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Aspectnaam,Informatie,Gebruikersnaam")] FIETSBENODIGDHEDEN fIETSBENODIGDHEDEN)
        {
            if (ModelState.IsValid)
            {
                db.FIETSBENODIGDHEDEN.Add(fIETSBENODIGDHEDEN);
                db.SaveChanges();
                return RedirectToAction("IndexAdmin");
            }

            ViewBag.UserID = new SelectList(db.ACCOUNT, "Gebruikersnaam", "Wachtwoord", fIETSBENODIGDHEDEN.Gebruikersnaam);
            return View(fIETSBENODIGDHEDEN);
        }

        // GET: FIETSBENODIGDHEDENs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FIETSBENODIGDHEDEN fIETSBENODIGDHEDEN = db.FIETSBENODIGDHEDEN.Find(id);
            if (fIETSBENODIGDHEDEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.ACCOUNT, "Gebruikersnaam", "Wachtwoord", fIETSBENODIGDHEDEN.Gebruikersnaam);
            return View(fIETSBENODIGDHEDEN);
        }

        // POST: FIETSBENODIGDHEDENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Aspectnaam,Informatie,Gebruikersnaam")] FIETSBENODIGDHEDEN fIETSBENODIGDHEDEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fIETSBENODIGDHEDEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexAdmin");
            }
            ViewBag.UserID = new SelectList(db.ACCOUNT, "Gebruikersnaam", "Wachtwoord", fIETSBENODIGDHEDEN.Gebruikersnaam);
            return View(fIETSBENODIGDHEDEN);
        }

        // GET: FIETSBENODIGDHEDENs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FIETSBENODIGDHEDEN fIETSBENODIGDHEDEN = db.FIETSBENODIGDHEDEN.Find(id);
            if (fIETSBENODIGDHEDEN == null)
            {
                return HttpNotFound();
            }
            return View(fIETSBENODIGDHEDEN);
        }

        // POST: FIETSBENODIGDHEDENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FIETSBENODIGDHEDEN fIETSBENODIGDHEDEN = db.FIETSBENODIGDHEDEN.Find(id);
            db.FIETSBENODIGDHEDEN.Remove(fIETSBENODIGDHEDEN);
            db.SaveChanges();
            return RedirectToAction("IndexAdmin");
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
