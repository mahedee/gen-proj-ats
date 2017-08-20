using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ATS.Models;

namespace ATS.Controllers
{
    public class MenufecturersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Menufecturers
        public ActionResult Index()
        {
            return View(db.Menufecturers.ToList());
        }

        // GET: Menufecturers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menufecturer menufecturer = db.Menufecturers.Find(id);
            if (menufecturer == null)
            {
                return HttpNotFound();
            }
            return View(menufecturer);
        }

        // GET: Menufecturers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Menufecturers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,City,Country,Email,Phone,WebAddress,CreateDate,ActionDate")] Menufecturer menufecturer)
        {
            menufecturer.CreateDate = DateTime.Now;
            menufecturer.ActionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Menufecturers.Add(menufecturer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menufecturer);
        }

        // GET: Menufecturers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menufecturer menufecturer = db.Menufecturers.Find(id);
            if (menufecturer == null)
            {
                return HttpNotFound();
            }
            return View(menufecturer);
        }

        // POST: Menufecturers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,City,Country,Email,Phone,WebAddress,CreateDate,ActionDate")] Menufecturer menufecturer)
        {
            menufecturer.ActionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(menufecturer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menufecturer);
        }

        // GET: Menufecturers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menufecturer menufecturer = db.Menufecturers.Find(id);
            if (menufecturer == null)
            {
                return HttpNotFound();
            }
            return View(menufecturer);
        }

        // POST: Menufecturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menufecturer menufecturer = db.Menufecturers.Find(id);
            db.Menufecturers.Remove(menufecturer);
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
