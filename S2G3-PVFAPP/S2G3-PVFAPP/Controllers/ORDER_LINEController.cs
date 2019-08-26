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
    public class ORDER_LINEController : Controller
    {
        private S2G3_PVFDBEntities db = new S2G3_PVFDBEntities();

        // GET: ORDER_LINE
        public ActionResult Index()
        {
            var oRDER_LINE = db.ORDER_LINE.Include(o => o.ORDER).Include(o => o.PRODUCT);
            return View(oRDER_LINE.ToList());
        }

        // GET: ORDER_LINE/Details/5
        public ActionResult Details(string orderID ,string productID)
        {
            if (orderID == null || productID==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER_LINE oRDER_LINE = db.ORDER_LINE.Find(orderID, productID);
            if (oRDER_LINE == null)
            {
                return HttpNotFound();
            }
            return View(oRDER_LINE);
        }

        // GET: ORDER_LINE/Create
        public ActionResult Create()
        {
            ViewBag.Order_ID = new SelectList(db.ORDER, "Order_ID", "Order_ID");
            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description");
            return View();
        }

        // POST: ORDER_LINE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_ID,Product_ID,Ordered_Quantity")] ORDER_LINE oRDER_LINE)
        {
            if (ModelState.IsValid)
            {
                db.ORDER_LINE.Add(oRDER_LINE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Order_ID = new SelectList(db.ORDER, "Order_ID", "Order_ID", oRDER_LINE.Order_ID);
            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description", oRDER_LINE.Product_ID);
            return View(oRDER_LINE);
        }

        // GET: ORDER_LINE/Edit/5
        public ActionResult Edit(string orderID, string productID)
        {
            if (orderID == null || productID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER_LINE oRDER_LINE = db.ORDER_LINE.Find(orderID, productID);
            if (oRDER_LINE == null)
            {
                return HttpNotFound();
            }
            ViewBag.Order_ID = new SelectList(db.ORDER, "Order_ID", "Order_ID", oRDER_LINE.Order_ID);
            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description", oRDER_LINE.Product_ID);
            return View(oRDER_LINE);
        }

        // POST: ORDER_LINE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_ID,Product_ID,Ordered_Quantity")] ORDER_LINE oRDER_LINE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oRDER_LINE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Order_ID = new SelectList(db.ORDER, "Order_ID", "Order_ID", oRDER_LINE.Order_ID);
            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description", oRDER_LINE.Product_ID);
            return View(oRDER_LINE);
        }

        // GET: ORDER_LINE/Delete/5
        public ActionResult Delete(string orderID, string productID)
        {
            if (orderID == null || productID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER_LINE oRDER_LINE = db.ORDER_LINE.Find(orderID, productID);
            if (oRDER_LINE == null)
            {
                return HttpNotFound();
            }
            return View(oRDER_LINE);
        }

        // POST: ORDER_LINE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string orderID, string productID)
        {
            ORDER_LINE oRDER_LINE = db.ORDER_LINE.Find(orderID, productID);
            db.ORDER_LINE.Remove(oRDER_LINE);
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
