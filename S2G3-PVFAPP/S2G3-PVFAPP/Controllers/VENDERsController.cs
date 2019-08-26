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
    public class VENDERsController : Controller
    {
        private S2G3_PVFDBEntities db = new S2G3_PVFDBEntities();

        // GET: VENDERs
        public ActionResult Index()
        {
            return View(db.VENDER.ToList());
        }

        // GET: VENDERs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENDER vENDER = db.VENDER.Find(id);
            if (vENDER == null)
            {
                return HttpNotFound();
            }
            return View(vENDER);
        }

        // GET: VENDERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VENDERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Vender_ID,Vender_Name,Vender_Address")] VENDER vENDER)
        {
            if (ModelState.IsValid)
            {
                db.VENDER.Add(vENDER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vENDER);
        }

        // GET: VENDERs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENDER vENDER = db.VENDER.Find(id);
            if (vENDER == null)
            {
                return HttpNotFound();
            }
            return View(vENDER);
        }

        // POST: VENDERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vender_ID,Vender_Name,Vender_Address")] VENDER vENDER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vENDER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vENDER);
        }

        // GET: VENDERs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENDER vENDER = db.VENDER.Find(id);
            if (vENDER == null)
            {
                return HttpNotFound();
            }
            return View(vENDER);
        }

        // POST: VENDERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VENDER vENDER = db.VENDER.Find(id);
            db.VENDER.Remove(vENDER);
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
