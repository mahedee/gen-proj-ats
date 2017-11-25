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
    public class CatagoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Catagories
        public ActionResult Index()
        {
            var catagory = db.Catagory.Include(c => c.CateType);
            return View(catagory.ToList());
        }

        // GET: Catagories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catagory catagory = db.Catagory.Find(id);
            if (catagory == null)
            {
                return HttpNotFound();
            }
            return View(catagory);
        }

        // GET: Catagories/Create
        public ActionResult Create()
        {
            ViewBag.CateTypeId = new SelectList(db.CateType, "TypeId", "Name");
            return View();
        }

        // POST: Catagories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CateTypeId,CreateDate,ActionDate")] Catagory catagory)
        {
            catagory.ActionDate = DateTime.Now;
            catagory.CreateDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Catagory.Add(catagory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CateTypeId = new SelectList(db.CateType, "TypeId", "Name", catagory.CateTypeId);
            return View(catagory);
        }

        // GET: Catagories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catagory catagory = db.Catagory.Find(id);
            if (catagory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CateTypeId = new SelectList(db.CateType, "TypeId", "Name", catagory.CateTypeId);
            return View(catagory);
        }

        // POST: Catagories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CateTypeId,CreateDate,ActionDate")] Catagory catagory)
        {
            catagory.ActionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(catagory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CateTypeId = new SelectList(db.CateType, "TypeId", "Name", catagory.CateTypeId);
            return View(catagory);
        }

        // GET: Catagories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catagory catagory = db.Catagory.Find(id);
            if (catagory == null)
            {
                return HttpNotFound();
            }
            return View(catagory);
        }

        // POST: Catagories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Catagory catagory = db.Catagory.Find(id);
            db.Catagory.Remove(catagory);
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
