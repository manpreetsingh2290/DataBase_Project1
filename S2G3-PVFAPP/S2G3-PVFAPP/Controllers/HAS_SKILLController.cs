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
    public class HAS_SKILLController : Controller
    {
        private S2G3_PVFDBEntities db = new S2G3_PVFDBEntities();

        // GET: HAS_SKILL
        public ActionResult Index()
        {
            var hAS_SKILL = db.HAS_SKILL.Include(h => h.EMPLOYEE).Include(h => h.SKILL);
            return View(hAS_SKILL.ToList());
        }

        // GET: HAS_SKILL/Details/5
        public ActionResult Details(string employeeID, string skillID)
        {
            if (employeeID==null || skillID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HAS_SKILL hAS_SKILL = db.HAS_SKILL.Find(employeeID, skillID);
            if (hAS_SKILL == null)
            {
                return HttpNotFound();
            }
            return View(hAS_SKILL);
        }

        // GET: HAS_SKILL/Create
        public ActionResult Create()
        {
            ViewBag.Employee_ID = new SelectList(db.EMPLOYEE, "Employee_ID", "Employee_Name");
            ViewBag.Skill_ID = new SelectList(db.SKILL, "Skill_ID", "Skill_Name");
            return View();
        }

        // POST: HAS_SKILL/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_ID,Skill_ID,Enable_Flag")] HAS_SKILL hAS_SKILL)
        {
            if (ModelState.IsValid)
            {
                db.HAS_SKILL.Add(hAS_SKILL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_ID = new SelectList(db.EMPLOYEE, "Employee_ID", "Employee_Name", hAS_SKILL.Employee_ID);
            ViewBag.Skill_ID = new SelectList(db.SKILL, "Skill_ID", "Skill_Name", hAS_SKILL.Skill_ID);
            return View(hAS_SKILL);
        }

        // GET: HAS_SKILL/Edit/5
        public ActionResult Edit(string employeeID, string skillID)
        {
            if (employeeID == null || skillID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HAS_SKILL hAS_SKILL = db.HAS_SKILL.Find(employeeID, skillID);
            if (hAS_SKILL == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_ID = new SelectList(db.EMPLOYEE, "Employee_ID", "Employee_Name", hAS_SKILL.Employee_ID);
            ViewBag.Skill_ID = new SelectList(db.SKILL, "Skill_ID", "Skill_Name", hAS_SKILL.Skill_ID);
            return View(hAS_SKILL);
        }

        // POST: HAS_SKILL/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_ID,Skill_ID,Enable_Flag")] HAS_SKILL hAS_SKILL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hAS_SKILL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_ID = new SelectList(db.EMPLOYEE, "Employee_ID", "Employee_Name", hAS_SKILL.Employee_ID);
            ViewBag.Skill_ID = new SelectList(db.SKILL, "Skill_ID", "Skill_Name", hAS_SKILL.Skill_ID);
            return View(hAS_SKILL);
        }

        // GET: HAS_SKILL/Delete/5
        public ActionResult Delete(string employeeID, string skillID)
        {
            if (employeeID == null || skillID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HAS_SKILL hAS_SKILL = db.HAS_SKILL.Find(employeeID, skillID);
            if (hAS_SKILL == null)
            {
                return HttpNotFound();
            }
            return View(hAS_SKILL);
        }

        // POST: HAS_SKILL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HAS_SKILL hAS_SKILL = db.HAS_SKILL.Find(id);
            db.HAS_SKILL.Remove(hAS_SKILL);
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
