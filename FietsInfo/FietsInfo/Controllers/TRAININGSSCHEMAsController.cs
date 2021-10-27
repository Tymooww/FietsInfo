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
    public class TRAININGSSCHEMAsController : Controller
    {
        private DatabaseModel db = new DatabaseModel();

        // GET: TRAININGSSCHEMAs
        public ActionResult Index()
        {
            return View(db.TRAININGSSCHEMA.ToList());
        }

        // GET: TRAININGSSCHEMAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRAININGSSCHEMA tRAININGSSCHEMA = db.TRAININGSSCHEMA.Find(id);
            if (tRAININGSSCHEMA == null)
            {
                return HttpNotFound();
            }
            return View(tRAININGSSCHEMA);
        }

        // GET: TRAININGSSCHEMAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TRAININGSSCHEMAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Trainingsnaam,Omschrijving,Urenmaandag,Urendinsdag,Urenwoensdag,Urendonderdag,Urenvrijdag,Urenzaterdag,Urenzondag,trainingsniveau")] TRAININGSSCHEMA tRAININGSSCHEMA)
        {
            if (ModelState.IsValid)
            {
                db.TRAININGSSCHEMA.Add(tRAININGSSCHEMA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tRAININGSSCHEMA);
        }

        // GET: TRAININGSSCHEMAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRAININGSSCHEMA tRAININGSSCHEMA = db.TRAININGSSCHEMA.Find(id);
            if (tRAININGSSCHEMA == null)
            {
                return HttpNotFound();
            }
            return View(tRAININGSSCHEMA);
        }

        // POST: TRAININGSSCHEMAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Trainingsnaam,Omschrijving,Urenmaandag,Urendinsdag,Urenwoensdag,Urendonderdag,Urenvrijdag,Urenzaterdag,Urenzondag,trainingsniveau")] TRAININGSSCHEMA tRAININGSSCHEMA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRAININGSSCHEMA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tRAININGSSCHEMA);
        }

        // GET: TRAININGSSCHEMAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRAININGSSCHEMA tRAININGSSCHEMA = db.TRAININGSSCHEMA.Find(id);
            if (tRAININGSSCHEMA == null)
            {
                return HttpNotFound();
            }
            return View(tRAININGSSCHEMA);
        }

        // POST: TRAININGSSCHEMAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TRAININGSSCHEMA tRAININGSSCHEMA = db.TRAININGSSCHEMA.Find(id);
            db.TRAININGSSCHEMA.Remove(tRAININGSSCHEMA);
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
