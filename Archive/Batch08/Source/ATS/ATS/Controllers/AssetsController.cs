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
    public class AssetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Assets
        public ActionResult Index()
        {
            var asset = db.Asset.Include(a => a.Branch).Include(a => a.Model).Include(a => a.Organization).Include(a => a.Status).Include(a => a.Supplier);
            return View(asset.ToList());
        }

        // GET: Assets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = db.Asset.Find(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }

        // GET: Assets/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name");
            ViewBag.ModelId = new SelectList(db.Model, "Id", "Name");
            ViewBag.CompanyId = new SelectList(db.Organizations, "Id", "Name");
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Name");
            ViewBag.SupplierId = new SelectList(db.Supplier, "Id", "Name");
            return View();
        }

        // POST: Assets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyId,AssetTag,ModelId,StatusId,Serial,Name,PurchaseDate,SupplierId,OrderNumber,Cost,Warranty,BranchId,Note,CreateDate,ActionDate")] Asset asset)
        {
            asset.CreateDate = DateTime.Now;
            asset.ActionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Asset.Add(asset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", asset.BranchId);
            ViewBag.ModelId = new SelectList(db.Model, "Id", "Name", asset.ModelId);
            ViewBag.CompanyId = new SelectList(db.Organizations, "Id", "Name", asset.CompanyId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Name", asset.StatusId);
            ViewBag.SupplierId = new SelectList(db.Supplier, "Id", "Name", asset.SupplierId);
            return View(asset);
        }

        // GET: Assets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = db.Asset.Find(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", asset.BranchId);
            ViewBag.ModelId = new SelectList(db.Model, "Id", "Name", asset.ModelId);
            ViewBag.CompanyId = new SelectList(db.Organizations, "Id", "Name", asset.CompanyId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Name", asset.StatusId);
            ViewBag.SupplierId = new SelectList(db.Supplier, "Id", "Name", asset.SupplierId);
            return View(asset);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyId,AssetTag,ModelId,StatusId,Serial,Name,PurchaseDate,SupplierId,OrderNumber,Cost,Warranty,BranchId,Note,CreateDate,ActionDate")] Asset asset)
        {
            asset.ActionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(asset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", asset.BranchId);
            ViewBag.ModelId = new SelectList(db.Model, "Id", "Name", asset.ModelId);
            ViewBag.CompanyId = new SelectList(db.Organizations, "Id", "Name", asset.CompanyId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Name", asset.StatusId);
            ViewBag.SupplierId = new SelectList(db.Supplier, "Id", "Name", asset.SupplierId);
            return View(asset);
        }

        // GET: Assets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = db.Asset.Find(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asset asset = db.Asset.Find(id);
            db.Asset.Remove(asset);
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
