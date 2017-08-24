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
    public class FieldsetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Fieldsets
        public ActionResult Index()
        {
            return View(db.Fieldset.ToList());
        }

        // GET: Fieldsets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fieldset fieldset = db.Fieldset.Find(id);
            if (fieldset == null)
            {
                return HttpNotFound();
            }
            return View(fieldset);
        }

        // GET: Fieldsets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fieldsets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CreateDate,ActionDate")] Fieldset fieldset)
        {
            fieldset.CreateDate = DateTime.Now;
            fieldset.ActionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Fieldset.Add(fieldset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fieldset);
        }

        // GET: Fieldsets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fieldset fieldset = db.Fieldset.Find(id);
            if (fieldset == null)
            {
                return HttpNotFound();
            }
            return View(fieldset);
        }

        // POST: Fieldsets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreateDate,ActionDate")] Fieldset fieldset)
        {
            fieldset.ActionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(fieldset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fieldset);
        }

        // GET: Fieldsets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fieldset fieldset = db.Fieldset.Find(id);
            if (fieldset == null)
            {
                return HttpNotFound();
            }
            return View(fieldset);
        }

        // POST: Fieldsets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fieldset fieldset = db.Fieldset.Find(id);
            db.Fieldset.Remove(fieldset);
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
