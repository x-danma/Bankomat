using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bankomat.DAL;
using Bankomat.Models;

namespace Bankomat.Controllers
{
    public class AtmController : Controller
    {
        private BankomatContext db = new BankomatContext();

        //public ActionResult UseAtm(int? id)
        //{


        //    return View()
        //}

        // GET: Atm
        public ActionResult Index()
        {
            return View(db.Atms.ToList());
        }

        // GET: Atm/Details/5
        public ActionResult UseAtm(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atm atm = db.Atms.Find(id);
            if (atm == null)
            {
                return HttpNotFound();
            }
            return View(atm);
        }

        // GET: Atm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Atm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AtmID,Bills100,Bills500,Receipts")] Atm atm)
        {
            if (ModelState.IsValid)
            {
                db.Atms.Add(atm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(atm);
        }

        // GET: Atm/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atm atm = db.Atms.Find(id);
            if (atm == null)
            {
                return HttpNotFound();
            }
            return View(atm);
        }

        // POST: Atm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AtmID,Bills100,Bills500,Receipts")] Atm atm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atm);
        }

        // GET: Atm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atm atm = db.Atms.Find(id);
            if (atm == null)
            {
                return HttpNotFound();
            }
            return View(atm);
        }

        // POST: Atm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atm atm = db.Atms.Find(id);
            db.Atms.Remove(atm);
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
