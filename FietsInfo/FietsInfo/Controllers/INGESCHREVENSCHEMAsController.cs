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
            var iNGESCHREVENSCHEMA = db.INGESCHREVENSCHEMA.Include(i => i.ACCOUNT).Include(i => i.TRAININGSSCHEMA);
            return View(iNGESCHREVENSCHEMA.ToList());
        }

        // GET: INGESCHREVENSCHEMAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INGESCHREVENSCHEMA iNGESCHREVENSCHEMA = db.INGESCHREVENSCHEMA.Find(id);
            if (iNGESCHREVENSCHEMA == null)
            {
                return HttpNotFound();
            }
            return View(iNGESCHREVENSCHEMA);
        }

        // GET: INGESCHREVENSCHEMAs/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.ACCOUNT, "UserID", "Wachtwoord");
            ViewBag.Trainingsnaam = new SelectList(db.TRAININGSSCHEMA, "Trainingsnaam", "Omschrijving");
            return View();
        }

        // POST: INGESCHREVENSCHEMAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Trainingsnaam,IsVoltooid,DagenVoltooid")] INGESCHREVENSCHEMA iNGESCHREVENSCHEMA)
        {
            if (ModelState.IsValid)
            {
                db.INGESCHREVENSCHEMA.Add(iNGESCHREVENSCHEMA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.ACCOUNT, "UserID", "Wachtwoord", iNGESCHREVENSCHEMA.UserID);
            ViewBag.Trainingsnaam = new SelectList(db.TRAININGSSCHEMA, "Trainingsnaam", "Omschrijving", iNGESCHREVENSCHEMA.Trainingsnaam);
            return View(iNGESCHREVENSCHEMA);
        }

        // GET: INGESCHREVENSCHEMAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INGESCHREVENSCHEMA iNGESCHREVENSCHEMA = db.INGESCHREVENSCHEMA.Find(id);
            if (iNGESCHREVENSCHEMA == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.ACCOUNT, "UserID", "Wachtwoord", iNGESCHREVENSCHEMA.UserID);
            ViewBag.Trainingsnaam = new SelectList(db.TRAININGSSCHEMA, "Trainingsnaam", "Omschrijving", iNGESCHREVENSCHEMA.Trainingsnaam);
            return View(iNGESCHREVENSCHEMA);
        }

        // POST: INGESCHREVENSCHEMAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Trainingsnaam,IsVoltooid,DagenVoltooid")] INGESCHREVENSCHEMA iNGESCHREVENSCHEMA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNGESCHREVENSCHEMA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.ACCOUNT, "UserID", "Wachtwoord", iNGESCHREVENSCHEMA.UserID);
            ViewBag.Trainingsnaam = new SelectList(db.TRAININGSSCHEMA, "Trainingsnaam", "Omschrijving", iNGESCHREVENSCHEMA.Trainingsnaam);
            return View(iNGESCHREVENSCHEMA);
        }

        // GET: INGESCHREVENSCHEMAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INGESCHREVENSCHEMA iNGESCHREVENSCHEMA = db.INGESCHREVENSCHEMA.Find(id);
            if (iNGESCHREVENSCHEMA == null)
            {
                return HttpNotFound();
            }
            return View(iNGESCHREVENSCHEMA);
        }

        // POST: INGESCHREVENSCHEMAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INGESCHREVENSCHEMA iNGESCHREVENSCHEMA = db.INGESCHREVENSCHEMA.Find(id);
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
