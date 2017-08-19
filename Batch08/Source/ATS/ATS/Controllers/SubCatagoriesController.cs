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
    public class SubCatagoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubCatagories
        public ActionResult Index()
        {
            var subCatagories = db.SubCatagories.Include(s => s.Catagory);
            return View(subCatagories.ToList());
        }

        // GET: SubCatagories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCatagory subCatagory = db.SubCatagories.Find(id);
            if (subCatagory == null)
            {
                return HttpNotFound();
            }
            return View(subCatagory);
        }

        // GET: SubCatagories/Create
        public ActionResult Create()
        {
            ViewBag.CateId = new SelectList(db.Catagories, "Id", "Name");
            return View();
        }

        // POST: SubCatagories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CateId,CreateDate,ActionDate")] SubCatagory subCatagory)
        {
            subCatagory.CreateDate = DateTime.Now;
            subCatagory.ActionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.SubCatagories.Add(subCatagory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CateId = new SelectList(db.Catagories, "Id", "Name", subCatagory.CateId);
            return View(subCatagory);
        }

        // GET: SubCatagories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCatagory subCatagory = db.SubCatagories.Find(id);
            if (subCatagory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CateId = new SelectList(db.Catagories, "Id", "Name", subCatagory.CateId);
            return View(subCatagory);
        }

        // POST: SubCatagories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CateId,CreateDate,ActionDate")] SubCatagory subCatagory)
        {
            subCatagory.CreateDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(subCatagory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CateId = new SelectList(db.Catagories, "Id", "Name", subCatagory.CateId);
            return View(subCatagory);
        }

        // GET: SubCatagories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCatagory subCatagory = db.SubCatagories.Find(id);
            if (subCatagory == null)
            {
                return HttpNotFound();
            }
            return View(subCatagory);
        }

        // POST: SubCatagories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCatagory subCatagory = db.SubCatagories.Find(id);
            db.SubCatagories.Remove(subCatagory);
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
