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
    [RoutePrefix("Model")]
    public class ModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Route]
        // GET: Models
        public ActionResult Index()
        {
            var model = db.Model.Include(m => m.Category).Include(m => m.Fieldset).Include(m => m.Manufacturer);
            return View(model.ToList());
        }

        // GET: Models/Details/5
        [Route]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Model.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Models/Create
        [Route]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Catagory, "Id", "Name");
            ViewBag.FieldsetId = new SelectList(db.Fieldset, "Id", "Name");
            ViewBag.MenuId = new SelectList(db.Manufacturers, "Id", "Name");
            return View();
        }

        // POST: Models/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route]
        public ActionResult Create([Bind(Include = "Id,Name,MenuId,CategoryId,ModelNo,Depreciation,Eol,FieldsetId,Note,CreateDate,ActionDate")] Model model)
        {
            model.CreateDate = DateTime.Now;
            model.ActionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Model.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Catagory, "Id", "Name", model.CategoryId);
            ViewBag.FieldsetId = new SelectList(db.Fieldset, "Id", "Name", model.FieldsetId);
            ViewBag.MenuId = new SelectList(db.Manufacturers, "Id", "Name", model.MenuId);
            return View(model);
        }

        // GET: Models/Edit/5
        [Route]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Model.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Catagory, "Id", "Name", model.CategoryId);
            ViewBag.FieldsetId = new SelectList(db.Fieldset, "Id", "Name", model.FieldsetId);
            ViewBag.MenuId = new SelectList(db.Manufacturers, "Id", "Name", model.MenuId);
            return View(model);
        }

        // POST: Models/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route]
        public ActionResult Edit([Bind(Include = "Id,Name,MenuId,CategoryId,ModelNo,Depreciation,Eol,FieldsetId,Note,CreateDate,ActionDate")] Model model)
        {
            model.ActionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Catagory, "Id", "Name", model.CategoryId);
            ViewBag.FieldsetId = new SelectList(db.Fieldset, "Id", "Name", model.FieldsetId);
            ViewBag.MenuId = new SelectList(db.Manufacturers, "Id", "Name", model.MenuId);
            return View(model);
        }

        // GET: Models/Delete/5
        [Route]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Model.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Models/Delete/5
        [Route]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Model model = db.Model.Find(id);
            db.Model.Remove(model);
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
