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
    public class WORKS_INController : Controller
    {
        private S2G3_PVFDBEntities db = new S2G3_PVFDBEntities();

        // GET: WORKS_IN
        public ActionResult Index()
        {
            var wORKS_IN = db.WORKS_IN.Include(w => w.EMPLOYEE).Include(w => w.WORK_CENTER);
            return View(wORKS_IN.ToList());
        }

        // GET: WORKS_IN/Details/5
        public ActionResult Details(string employeeID, string workCenterID)
        {
            if (employeeID == null || workCenterID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WORKS_IN wORKS_IN = db.WORKS_IN.Find(employeeID, workCenterID);
            if (wORKS_IN == null)
            {
                return HttpNotFound();
            }
            return View(wORKS_IN);
        }

        // GET: WORKS_IN/Create
        public ActionResult Create()
        {
            ViewBag.Employee_ID = new SelectList(db.EMPLOYEE, "Employee_ID", "Employee_Name");
            ViewBag.Work_Center_ID = new SelectList(db.WORK_CENTER, "Work_Center_ID", "Work_Center_Location");
            return View();
        }

        // POST: WORKS_IN/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_ID,Work_Center_ID,Joining_Date,Enable_Flag")] WORKS_IN wORKS_IN)
        {
            if (ModelState.IsValid)
            {
                db.WORKS_IN.Add(wORKS_IN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_ID = new SelectList(db.EMPLOYEE, "Employee_ID", "Employee_Name", wORKS_IN.Employee_ID);
            ViewBag.Work_Center_ID = new SelectList(db.WORK_CENTER, "Work_Center_ID", "Work_Center_Location", wORKS_IN.Work_Center_ID);
            return View(wORKS_IN);
        }

        // GET: WORKS_IN/Edit/5
        public ActionResult Edit(string employeeID,string workCenterID)
        {
            if (employeeID == null || workCenterID==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WORKS_IN wORKS_IN = db.WORKS_IN.Find(employeeID,workCenterID);
            if (wORKS_IN == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_ID = new SelectList(db.EMPLOYEE, "Employee_ID", "Employee_Name", wORKS_IN.Employee_ID);
            ViewBag.Work_Center_ID = new SelectList(db.WORK_CENTER, "Work_Center_ID", "Work_Center_Location", wORKS_IN.Work_Center_ID);
            return View(wORKS_IN);
        }

        // POST: WORKS_IN/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_ID,Work_Center_ID,Joining_Date,Enable_Flag")] WORKS_IN wORKS_IN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wORKS_IN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_ID = new SelectList(db.EMPLOYEE, "Employee_ID", "Employee_Name", wORKS_IN.Employee_ID);
            ViewBag.Work_Center_ID = new SelectList(db.WORK_CENTER, "Work_Center_ID", "Work_Center_Location", wORKS_IN.Work_Center_ID);
            return View(wORKS_IN);
        }

        // GET: WORKS_IN/Delete/5
        public ActionResult Delete(string employeeID, string workCenterID)
        {
            if (employeeID == null || workCenterID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WORKS_IN wORKS_IN = db.WORKS_IN.Find(employeeID, workCenterID);
            if (wORKS_IN == null)
            {
                return HttpNotFound();
            }
            return View(wORKS_IN);
        }

        // POST: WORKS_IN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string employeeID, string workCenterID)
        {
            WORKS_IN wORKS_IN = db.WORKS_IN.Find(employeeID, workCenterID);
            db.WORKS_IN.Remove(wORKS_IN);
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
