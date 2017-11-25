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
    public class AccessoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Accessories
        public ActionResult Index()
        {
            var accessory = db.Accessory.Include(a => a.Branch).Include(a => a.Category).Include(a => a.Manufacturer).Include(a => a.Organization);
            return View(accessory.ToList());
        }

        // GET: Accessories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessory accessory = db.Accessory.Find(id);
            if (accessory == null)
            {
                return HttpNotFound();
            }
            return View(accessory);
        }

        // GET: Accessories/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name");
            ViewBag.CateId = new SelectList(db.Catagory, "Id", "Name");
            ViewBag.ManuId = new SelectList(db.Manufacturers, "Id", "Name");
            ViewBag.CompanyId = new SelectList(db.Organizations, "Id", "Name");
            return View();
        }

        // POST: Accessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyId,Name,CateId,ManuId,BranchId,ModelNo,OrderNo,PurchaseCost,PurchaseDate,Quantity,CreateDate,ActionDate")] Accessory accessory)
        {
            accessory.CreateDate = DateTime.Now;
            accessory.ActionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Accessory.Add(accessory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", accessory.BranchId);
            ViewBag.CateId = new SelectList(db.Catagory, "Id", "Name", accessory.CateId);
            ViewBag.ManuId = new SelectList(db.Manufacturers, "Id", "Name", accessory.ManuId);
            ViewBag.CompanyId = new SelectList(db.Organizations, "Id", "Name", accessory.CompanyId);
            return View(accessory);
        }

        // GET: Accessories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessory accessory = db.Accessory.Find(id);
            if (accessory == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", accessory.BranchId);
            ViewBag.CateId = new SelectList(db.Catagory, "Id", "Name", accessory.CateId);
            ViewBag.ManuId = new SelectList(db.Manufacturers, "Id", "Name", accessory.ManuId);
            ViewBag.CompanyId = new SelectList(db.Organizations, "Id", "Name", accessory.CompanyId);
            return View(accessory);
        }

        // POST: Accessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyId,Name,CateId,ManuId,BranchId,ModelNo,OrderNo,PurchaseCost,PurchaseDate,Quantity,CreateDate,ActionDate")] Accessory accessory)
        {
            accessory.ActionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(accessory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", accessory.BranchId);
            ViewBag.CateId = new SelectList(db.Catagory, "Id", "Name", accessory.CateId);
            ViewBag.ManuId = new SelectList(db.Manufacturers, "Id", "Name", accessory.ManuId);
            ViewBag.CompanyId = new SelectList(db.Organizations, "Id", "Name", accessory.CompanyId);
            return View(accessory);
        }

        // GET: Accessories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessory accessory = db.Accessory.Find(id);
            if (accessory == null)
            {
                return HttpNotFound();
            }
            return View(accessory);
        }

        // POST: Accessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accessory accessory = db.Accessory.Find(id);
            db.Accessory.Remove(accessory);
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
