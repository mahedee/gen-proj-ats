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
    public class ConsumablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Consumables
        public ActionResult Index()
        {
            var consumable = db.Consumable.Include(c => c.Branch).Include(c => c.Category).Include(c => c.Manufacturer).Include(c => c.Organization);
            return View(consumable.ToList());
        }

        // GET: Consumables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumable consumable = db.Consumable.Find(id);
            if (consumable == null)
            {
                return HttpNotFound();
            }
            return View(consumable);
        }

        // GET: Consumables/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name");
            ViewBag.CategoryId = new SelectList(db.Catagory, "Id", "Name");
            ViewBag.ManuId = new SelectList(db.Manufacturers, "Id", "Name");
            ViewBag.CompanyId = new SelectList(db.Organizations, "Id", "Name");
            return View();
        }

        // POST: Consumables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyId,Name,CategoryId,ManuId,BranchId,ModelNo,ItemNo,OrderNo,PurchaseCost,PurchaseDate,Quantity,CreateDate,ActionDate")] Consumable consumable)
        {
            consumable.CreateDate = DateTime.Now;
            consumable.ActionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Consumable.Add(consumable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", consumable.BranchId);
            ViewBag.CategoryId = new SelectList(db.Catagory, "Id", "Name", consumable.CategoryId);
            ViewBag.ManuId = new SelectList(db.Manufacturers, "Id", "Name", consumable.ManuId);
            ViewBag.CompanyId = new SelectList(db.Organizations, "Id", "Name", consumable.CompanyId);
            return View(consumable);
        }

        // GET: Consumables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumable consumable = db.Consumable.Find(id);
            if (consumable == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", consumable.BranchId);
            ViewBag.CategoryId = new SelectList(db.Catagory, "Id", "Name", consumable.CategoryId);
            ViewBag.ManuId = new SelectList(db.Manufacturers, "Id", "Name", consumable.ManuId);
            ViewBag.CompanyId = new SelectList(db.Organizations, "Id", "Name", consumable.CompanyId);
            return View(consumable);
        }

        // POST: Consumables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyId,Name,CategoryId,ManuId,BranchId,ModelNo,ItemNo,OrderNo,PurchaseCost,PurchaseDate,Quantity,CreateDate,ActionDate")] Consumable consumable)
        {
            consumable.ActionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(consumable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", consumable.BranchId);
            ViewBag.CategoryId = new SelectList(db.Catagory, "Id", "Name", consumable.CategoryId);
            ViewBag.ManuId = new SelectList(db.Manufacturers, "Id", "Name", consumable.ManuId);
            ViewBag.CompanyId = new SelectList(db.Organizations, "Id", "Name", consumable.CompanyId);
            return View(consumable);
        }

        // GET: Consumables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumable consumable = db.Consumable.Find(id);
            if (consumable == null)
            {
                return HttpNotFound();
            }
            return View(consumable);
        }

        // POST: Consumables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consumable consumable = db.Consumable.Find(id);
            db.Consumable.Remove(consumable);
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
