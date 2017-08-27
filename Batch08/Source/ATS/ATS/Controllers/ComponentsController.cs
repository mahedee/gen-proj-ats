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
    public class ComponentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Components
        public ActionResult Index()
        {
            var components = db.Component.Include(c => c.Branch).Include(c => c.Category).Include(c => c.Organization);
            return View(components.ToList());
        }

        // GET: Components/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Component.Find(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            return View(component);
        }

        // GET: Components/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name");
            ViewBag.CategoryId = new SelectList(db.Catagory, "Id", "Name");
            ViewBag.CompanyId = new SelectList(db.Organizations, "Id", "Name");
            return View();
        }

        // POST: Components/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CategoryId,Quantity,SerialNo,CompanyId,BranchId,PurchaseCost,PurchaseDate,CreateDate,ActionDate")] Component component)
        {
            component.CreateDate = DateTime.Now;
            component.ActionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Component.Add(component);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", component.BranchId);
            ViewBag.CategoryId = new SelectList(db.Catagory, "Id", "Name", component.CategoryId);
            ViewBag.CompanyId = new SelectList(db.Organizations, "Id", "Name", component.CompanyId);
            return View(component);
        }

        // GET: Components/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Component.Find(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", component.BranchId);
            ViewBag.CategoryId = new SelectList(db.Catagory, "Id", "Name", component.CategoryId);
            ViewBag.CompanyId = new SelectList(db.Organizations, "Id", "Name", component.CompanyId);
            return View(component);
        }

        // POST: Components/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CategoryId,Quantity,SerialNo,CompanyId,BranchId,PurchaseCost,PurchaseDate,CreateDate,ActionDate")] Component component)
        {
            component.ActionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(component).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", component.BranchId);
            ViewBag.CategoryId = new SelectList(db.Catagory, "Id", "Name", component.CategoryId);
            ViewBag.CompanyId = new SelectList(db.Organizations, "Id", "Name", component.CompanyId);
            return View(component);
        }

        // GET: Components/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Component.Find(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            return View(component);
        }

        // POST: Components/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Component component = db.Component.Find(id);
            db.Component.Remove(component);
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
