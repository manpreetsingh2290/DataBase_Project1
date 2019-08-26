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
    public class USESController : Controller
    {
        private S2G3_PVFDBEntities db = new S2G3_PVFDBEntities();

        // GET: USES
        public ActionResult Index()
        {
            var uSES = db.USES.Include(u => u.PRODUCT).Include(u => u.RAW_MATERIAL);
            return View(uSES.ToList());
        }

        // GET: USES/Details/5
        public ActionResult Details(string productID, string materialID)
        {
            if (productID == null || materialID==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USES uSES = db.USES.Find(productID, materialID);
            if (uSES == null)
            {
                return HttpNotFound();
            }
            return View(uSES);
        }

        // GET: USES/Create
        public ActionResult Create()
        {
            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description");
            ViewBag.Material_ID = new SelectList(db.RAW_MATERIAL, "Material_ID", "Material_Name");
            return View();
        }

        // POST: USES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product_ID,Material_ID,Goes_Into_Quantity")] USES uSES)
        {
            if (ModelState.IsValid)
            {
                db.USES.Add(uSES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description", uSES.Product_ID);
            ViewBag.Material_ID = new SelectList(db.RAW_MATERIAL, "Material_ID", "Material_Name", uSES.Material_ID);
            return View(uSES);
        }

        // GET: USES/Edit/5
        public ActionResult Edit(string productID, string materialID)
        {
            if (productID == null || materialID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USES uSES = db.USES.Find(productID, materialID);
            if (uSES == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description", uSES.Product_ID);
            ViewBag.Material_ID = new SelectList(db.RAW_MATERIAL, "Material_ID", "Material_Name", uSES.Material_ID);
            return View(uSES);
        }

        // POST: USES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Product_ID,Material_ID,Goes_Into_Quantity")] USES uSES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description", uSES.Product_ID);
            ViewBag.Material_ID = new SelectList(db.RAW_MATERIAL, "Material_ID", "Material_Name", uSES.Material_ID);
            return View(uSES);
        }

        // GET: USES/Delete/5
        public ActionResult Delete(string productID, string materialID)
        {
            if (productID == null || materialID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USES uSES = db.USES.Find(productID, materialID);
            if (uSES == null)
            {
                return HttpNotFound();
            }
            return View(uSES);
        }

        // POST: USES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string productID, string materialID)
        {
            USES uSES = db.USES.Find(productID, materialID);
            db.USES.Remove(uSES);
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
