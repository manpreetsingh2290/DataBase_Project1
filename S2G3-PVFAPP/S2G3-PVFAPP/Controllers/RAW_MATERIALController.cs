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
    public class RAW_MATERIALController : Controller
    {
        private S2G3_PVFDBEntities db = new S2G3_PVFDBEntities();

        // GET: RAW_MATERIAL
        public ActionResult Index()
        {
            return View(db.RAW_MATERIAL.ToList());
        }

        // GET: RAW_MATERIAL/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAW_MATERIAL rAW_MATERIAL = db.RAW_MATERIAL.Find(id);
            if (rAW_MATERIAL == null)
            {
                return HttpNotFound();
            }
            return View(rAW_MATERIAL);
        }

        // GET: RAW_MATERIAL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RAW_MATERIAL/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Material_ID,Material_Name,Material_Standard_Cost,Unit_Of_Measure")] RAW_MATERIAL rAW_MATERIAL)
        {
            if (ModelState.IsValid)
            {
                db.RAW_MATERIAL.Add(rAW_MATERIAL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rAW_MATERIAL);
        }

        // GET: RAW_MATERIAL/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAW_MATERIAL rAW_MATERIAL = db.RAW_MATERIAL.Find(id);
            if (rAW_MATERIAL == null)
            {
                return HttpNotFound();
            }
            return View(rAW_MATERIAL);
        }

        // POST: RAW_MATERIAL/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Material_ID,Material_Name,Material_Standard_Cost,Unit_Of_Measure")] RAW_MATERIAL rAW_MATERIAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rAW_MATERIAL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rAW_MATERIAL);
        }

        // GET: RAW_MATERIAL/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAW_MATERIAL rAW_MATERIAL = db.RAW_MATERIAL.Find(id);
            if (rAW_MATERIAL == null)
            {
                return HttpNotFound();
            }
            return View(rAW_MATERIAL);
        }

        // POST: RAW_MATERIAL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            RAW_MATERIAL rAW_MATERIAL = db.RAW_MATERIAL.Find(id);
            db.RAW_MATERIAL.Remove(rAW_MATERIAL);
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
