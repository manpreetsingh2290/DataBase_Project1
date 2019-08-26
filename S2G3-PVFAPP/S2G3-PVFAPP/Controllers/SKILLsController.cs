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
    public class SKILLsController : Controller
    {
        private S2G3_PVFDBEntities db = new S2G3_PVFDBEntities();

        // GET: SKILLs
        public ActionResult Index()
        {
            return View(db.SKILL.ToList());
        }

        // GET: SKILLs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SKILL sKILL = db.SKILL.Find(id);
            if (sKILL == null)
            {
                return HttpNotFound();
            }
            return View(sKILL);
        }

        // GET: SKILLs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SKILLs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Skill_ID,Skill_Name")] SKILL sKILL)
        {
            if (ModelState.IsValid)
            {
                db.SKILL.Add(sKILL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sKILL);
        }

        // GET: SKILLs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SKILL sKILL = db.SKILL.Find(id);
            if (sKILL == null)
            {
                return HttpNotFound();
            }
            return View(sKILL);
        }

        // POST: SKILLs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Skill_ID,Skill_Name")] SKILL sKILL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sKILL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sKILL);
        }

        // GET: SKILLs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SKILL sKILL = db.SKILL.Find(id);
            if (sKILL == null)
            {
                return HttpNotFound();
            }
            return View(sKILL);
        }

        // POST: SKILLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SKILL sKILL = db.SKILL.Find(id);
            db.SKILL.Remove(sKILL);
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
