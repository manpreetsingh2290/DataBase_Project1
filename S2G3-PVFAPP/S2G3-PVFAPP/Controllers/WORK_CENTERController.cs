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
    public class WORK_CENTERController : Controller
    {
        private S2G3_PVFDBEntities db = new S2G3_PVFDBEntities();

        // GET: WORK_CENTER
        public ActionResult Index()
        {
            return View(db.WORK_CENTER.ToList());
        }

        // GET: WORK_CENTER/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WORK_CENTER wORK_CENTER = db.WORK_CENTER.Find(id);
            if (wORK_CENTER == null)
            {
                return HttpNotFound();
            }
            return View(wORK_CENTER);
        }

        // GET: WORK_CENTER/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WORK_CENTER/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Work_Center_ID,Work_Center_Location")] WORK_CENTER wORK_CENTER)
        {
            if (ModelState.IsValid)
            {
                db.WORK_CENTER.Add(wORK_CENTER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wORK_CENTER);
        }

        // GET: WORK_CENTER/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WORK_CENTER wORK_CENTER = db.WORK_CENTER.Find(id);
            if (wORK_CENTER == null)
            {
                return HttpNotFound();
            }
            return View(wORK_CENTER);
        }

        // POST: WORK_CENTER/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Work_Center_ID,Work_Center_Location")] WORK_CENTER wORK_CENTER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wORK_CENTER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wORK_CENTER);
        }

        // GET: WORK_CENTER/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WORK_CENTER wORK_CENTER = db.WORK_CENTER.Find(id);
            if (wORK_CENTER == null)
            {
                return HttpNotFound();
            }
            return View(wORK_CENTER);
        }

        // POST: WORK_CENTER/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            WORK_CENTER wORK_CENTER = db.WORK_CENTER.Find(id);
            db.WORK_CENTER.Remove(wORK_CENTER);
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
