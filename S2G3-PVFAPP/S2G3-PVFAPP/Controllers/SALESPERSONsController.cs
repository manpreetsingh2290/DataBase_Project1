using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S2G3_PVFAPP.Models;

namespace S2G3_PVFAPP.Controllers
{
    public class SALESPERSONsController : Controller
    {
        private S2G3_PVFDBEntities db = new S2G3_PVFDBEntities();

        // GET: SALESPERSONs
        public ActionResult Index()
        {
            var sALESPERSON = db.SALESPERSON.Include(s => s.TERRITORY);
            return View(sALESPERSON.ToList());
        }

        // GET: SALESPERSONs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALESPERSON sALESPERSON = db.SALESPERSON.Find(id);
            if (sALESPERSON == null)
            {
                return HttpNotFound();
            }
            return View(sALESPERSON);
        }

        // GET: SALESPERSONs/Create
        public ActionResult Create()
        {
            ViewBag.Territory_ID = new SelectList(db.TERRITORY, "Territory_ID", "Territory_ID");
            return View();
        }

        // POST: SALESPERSONs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Salesperson_ID,Salesperson_Name,Salesperson_Telephone,Salesperson_Fax,Territory_ID")] SALESPERSON sALESPERSON)
        {
            if (ModelState.IsValid)
            {
                db.SALESPERSON.Add(sALESPERSON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Territory_ID = new SelectList(db.TERRITORY, "Territory_ID", "Territory_ID", sALESPERSON.Territory_ID);
            return View(sALESPERSON);
        }

        // GET: SALESPERSONs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALESPERSON sALESPERSON = db.SALESPERSON.Find(id);
            if (sALESPERSON == null)
            {
                return HttpNotFound();
            }
            ViewBag.Territory_ID = new SelectList(db.TERRITORY, "Territory_ID", "Territory_ID", sALESPERSON.Territory_ID);
            return View(sALESPERSON);
        }

        // POST: SALESPERSONs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Salesperson_ID,Salesperson_Name,Salesperson_Telephone,Salesperson_Fax,Territory_ID")] SALESPERSON sALESPERSON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sALESPERSON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Territory_ID = new SelectList(db.TERRITORY, "Territory_ID", "Territory_ID", sALESPERSON.Territory_ID);
            return View(sALESPERSON);
        }

        // GET: SALESPERSONs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALESPERSON sALESPERSON = db.SALESPERSON.Find(id);
            if (sALESPERSON == null)
            {
                return HttpNotFound();
            }
            return View(sALESPERSON);
        }

        // POST: SALESPERSONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SALESPERSON sALESPERSON = db.SALESPERSON.Find(id);
            db.SALESPERSON.Remove(sALESPERSON);
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
