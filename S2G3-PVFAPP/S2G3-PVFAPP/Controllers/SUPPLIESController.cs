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
    public class SUPPLIESController : Controller
    {
        private S2G3_PVFDBEntities db = new S2G3_PVFDBEntities();

        // GET: SUPPLIES
        public ActionResult Index()
        {
            var sUPPLIES = db.SUPPLIES.Include(s => s.RAW_MATERIAL).Include(s => s.VENDER);
            return View(sUPPLIES.ToList());
        }

        // GET: SUPPLIES/Details/5
        public ActionResult Details(string venderID, string materialID)
        {
            if (venderID == null || materialID==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPPLIES sUPPLIES = db.SUPPLIES.Find(venderID, materialID);
            if (sUPPLIES == null)
            {
                return HttpNotFound();
            }
            return View(sUPPLIES);
        }

        // GET: SUPPLIES/Create
        public ActionResult Create()
        {
            ViewBag.Material_ID = new SelectList(db.RAW_MATERIAL, "Material_ID", "Material_Name");
            ViewBag.Vender_ID = new SelectList(db.VENDER, "Vender_ID", "Vender_Name");
            return View();
        }

        // POST: SUPPLIES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Vender_ID,Material_ID,Supply_Unit_Price")] SUPPLIES sUPPLIES)
        {
            if (ModelState.IsValid)
            {
                db.SUPPLIES.Add(sUPPLIES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Material_ID = new SelectList(db.RAW_MATERIAL, "Material_ID", "Material_Name", sUPPLIES.Material_ID);
            ViewBag.Vender_ID = new SelectList(db.VENDER, "Vender_ID", "Vender_Name", sUPPLIES.Vender_ID);
            return View(sUPPLIES);
        }

        // GET: SUPPLIES/Edit/5
        public ActionResult Edit(string venderID, string materialID)
        {
            if (venderID == null || materialID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPPLIES sUPPLIES = db.SUPPLIES.Find(venderID, materialID);
            if (sUPPLIES == null)
            {
                return HttpNotFound();
            }
            ViewBag.Material_ID = new SelectList(db.RAW_MATERIAL, "Material_ID", "Material_Name", sUPPLIES.Material_ID);
            ViewBag.Vender_ID = new SelectList(db.VENDER, "Vender_ID", "Vender_Name", sUPPLIES.Vender_ID);
            return View(sUPPLIES);
        }

        // POST: SUPPLIES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vender_ID,Material_ID,Supply_Unit_Price")] SUPPLIES sUPPLIES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUPPLIES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Material_ID = new SelectList(db.RAW_MATERIAL, "Material_ID", "Material_Name", sUPPLIES.Material_ID);
            ViewBag.Vender_ID = new SelectList(db.VENDER, "Vender_ID", "Vender_Name", sUPPLIES.Vender_ID);
            return View(sUPPLIES);
        }

        // GET: SUPPLIES/Delete/5
        public ActionResult Delete(string venderID, string materialID)
        {
            if (venderID == null || materialID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPPLIES sUPPLIES = db.SUPPLIES.Find(venderID, materialID);
            if (sUPPLIES == null)
            {
                return HttpNotFound();
            }
            return View(sUPPLIES);
        }

        // POST: SUPPLIES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string venderID, string materialID)
        {
            SUPPLIES sUPPLIES = db.SUPPLIES.Find(venderID, materialID);
            db.SUPPLIES.Remove(sUPPLIES);
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
