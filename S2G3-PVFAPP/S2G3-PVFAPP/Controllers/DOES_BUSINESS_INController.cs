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
    public class DOES_BUSINESS_INController : Controller
    {
        private S2G3_PVFDBEntities db = new S2G3_PVFDBEntities();

        // GET: DOES_BUSINESS_IN
        public ActionResult Index()
        {
            var dOES_BUSINESS_IN = db.DOES_BUSINESS_IN.Include(d => d.CUSTOMER).Include(d => d.TERRITORY);
            return View(dOES_BUSINESS_IN.ToList());
        }

        // GET: DOES_BUSINESS_IN/Details/5
        public ActionResult Details(string customerID, string territoryID)
        {
            if (customerID == null || territoryID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOES_BUSINESS_IN dOES_BUSINESS_IN = db.DOES_BUSINESS_IN.Find(customerID, territoryID);
            if (dOES_BUSINESS_IN == null)
            {
                return HttpNotFound();
            }
            return View(dOES_BUSINESS_IN);
        }

        // GET: DOES_BUSINESS_IN/Create
        public ActionResult Create()
        {
            ViewBag.Customer_ID = new SelectList(db.CUSTOMER, "Customer_ID", "Customer_Name");
            ViewBag.Territory_ID = new SelectList(db.TERRITORY, "Territory_ID", "Territory_ID");
            return View();
        }

        // POST: DOES_BUSINESS_IN/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Customer_ID,Territory_ID,Business_Start_Date,Business_End_Date")] DOES_BUSINESS_IN dOES_BUSINESS_IN)
        {
            if (ModelState.IsValid)
            {
                db.DOES_BUSINESS_IN.Add(dOES_BUSINESS_IN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_ID = new SelectList(db.CUSTOMER, "Customer_ID", "Customer_Name", dOES_BUSINESS_IN.Customer_ID);
            ViewBag.Territory_ID = new SelectList(db.TERRITORY, "Territory_ID", "Territory_ID", dOES_BUSINESS_IN.Territory_ID);
            return View(dOES_BUSINESS_IN);
        }

        // GET: DOES_BUSINESS_IN/Edit/5
        public ActionResult Edit(string customerID, string territoryID)
        {
            if (customerID ==null || territoryID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOES_BUSINESS_IN dOES_BUSINESS_IN = db.DOES_BUSINESS_IN.Find(customerID, territoryID);
            if (dOES_BUSINESS_IN == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_ID = new SelectList(db.CUSTOMER, "Customer_ID", "Customer_Name", dOES_BUSINESS_IN.Customer_ID);
            ViewBag.Territory_ID = new SelectList(db.TERRITORY, "Territory_ID", "Territory_ID", dOES_BUSINESS_IN.Territory_ID);
            return View(dOES_BUSINESS_IN);
        }

        // POST: DOES_BUSINESS_IN/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Customer_ID,Territory_ID,Business_Start_Date,Business_End_Date")] DOES_BUSINESS_IN dOES_BUSINESS_IN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOES_BUSINESS_IN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_ID = new SelectList(db.CUSTOMER, "Customer_ID", "Customer_Name", dOES_BUSINESS_IN.Customer_ID);
            ViewBag.Territory_ID = new SelectList(db.TERRITORY, "Territory_ID", "Territory_ID", dOES_BUSINESS_IN.Territory_ID);
            return View(dOES_BUSINESS_IN);
        }

        // GET: DOES_BUSINESS_IN/Delete/5
        public ActionResult Delete(string customerID, string territoryID)
        {
            if (customerID == null || territoryID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOES_BUSINESS_IN dOES_BUSINESS_IN = db.DOES_BUSINESS_IN.Find(customerID, territoryID);
            if (dOES_BUSINESS_IN == null)
            {
                return HttpNotFound();
            }
            return View(dOES_BUSINESS_IN);
        }

        // POST: DOES_BUSINESS_IN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string customerID, string territoryID)
        {
            DOES_BUSINESS_IN dOES_BUSINESS_IN = db.DOES_BUSINESS_IN.Find(customerID, territoryID);
            db.DOES_BUSINESS_IN.Remove(dOES_BUSINESS_IN);
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
