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
    public class TERRITORiesController : Controller
    {
        private S2G3_PVFDBEntities db = new S2G3_PVFDBEntities();

        // GET: TERRITORies
        public ActionResult Index()
        {
            return View(db.TERRITORY.ToList());
        }

        // GET: TERRITORies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TERRITORY tERRITORY = db.TERRITORY.Find(id);
            if (tERRITORY == null)
            {
                return HttpNotFound();
            }
            return View(tERRITORY);
        }

        // GET: TERRITORies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TERRITORies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Territory_ID,Territory_Name")] TERRITORY tERRITORY)
        {
            if (ModelState.IsValid)
            {
                db.TERRITORY.Add(tERRITORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tERRITORY);
        }

        // GET: TERRITORies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TERRITORY tERRITORY = db.TERRITORY.Find(id);
            if (tERRITORY == null)
            {
                return HttpNotFound();
            }
            return View(tERRITORY);
        }

        // POST: TERRITORies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Territory_ID,Territory_Name")] TERRITORY tERRITORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tERRITORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tERRITORY);
        }

        // GET: TERRITORies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TERRITORY tERRITORY = db.TERRITORY.Find(id);
            if (tERRITORY == null)
            {
                return HttpNotFound();
            }
            return View(tERRITORY);
        }

        // POST: TERRITORies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TERRITORY tERRITORY = db.TERRITORY.Find(id);
            db.TERRITORY.Remove(tERRITORY);
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
