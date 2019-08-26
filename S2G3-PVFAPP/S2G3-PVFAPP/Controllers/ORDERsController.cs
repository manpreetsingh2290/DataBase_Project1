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
    public class ORDERsController : Controller
    {
        private S2G3_PVFDBEntities db = new S2G3_PVFDBEntities();

        // GET: ORDERs
        public ActionResult Index()
        {
            var oRDER = db.ORDER.Include(o => o.CUSTOMER);
            return View(oRDER.ToList());
        }

        // GET: ORDERs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER oRDER = db.ORDER.Find(id);
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            return View(oRDER);
        }

        // GET: ORDERs/Create
        public ActionResult Create()
        {
            ViewBag.Customer_ID = new SelectList(db.CUSTOMER, "Customer_ID", "Customer_Name");
            return View();
        }

        // POST: ORDERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_ID,Order_Date,Customer_ID")] ORDER oRDER)
        {
            if (ModelState.IsValid)
            {
                db.ORDER.Add(oRDER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_ID = new SelectList(db.CUSTOMER, "Customer_ID", "Customer_Name", oRDER.Customer_ID);
            return View(oRDER);
        }

        // GET: ORDERs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER oRDER = db.ORDER.Find(id);
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_ID = new SelectList(db.CUSTOMER, "Customer_ID", "Customer_Name", oRDER.Customer_ID);
            return View(oRDER);
        }

        // POST: ORDERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_ID,Order_Date,Customer_ID")] ORDER oRDER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oRDER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_ID = new SelectList(db.CUSTOMER, "Customer_ID", "Customer_Name", oRDER.Customer_ID);
            return View(oRDER);
        }

        // GET: ORDERs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER oRDER = db.ORDER.Find(id);
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            return View(oRDER);
        }

        // POST: ORDERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ORDER oRDER = db.ORDER.Find(id);
            db.ORDER.Remove(oRDER);
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
