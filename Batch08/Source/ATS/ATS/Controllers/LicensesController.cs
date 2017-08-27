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
    public class LicensesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Licenses
        public ActionResult Index()
        {
            var licenses = db.License.Include(l => l.Manufacturer).Include(l => l.Organization).Include(l => l.Supplier);
            return View(licenses.ToList());
        }

        // GET: Licenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            License license = db.License.Find(id);
            if (license == null)
            {
                return HttpNotFound();
            }
            return View(license);
        }

        // GET: Licenses/Create
        public ActionResult Create()
        {
            ViewBag.MenuId = new SelectList(db.Manufacturers, "Id", "Name");
            ViewBag.CompanyId = new SelectList(db.Organizations, "Id", "Name");
            ViewBag.SupplierId = new SelectList(db.Supplier, "Id", "Name");
            return View();
        }

        // POST: Licenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ProductKey,Seats,CompanyId,MenuId,LicenseName,LicenseEmail,SupplierId,OrderNumber,PurchaseCost,PurchaseDate,ExpirationDate,OrderNo,Notes,CreateDate,ActionDate")] License license)
        {
            license.CreateDate = DateTime.Now;
            license.ActionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.License.Add(license);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MenuId = new SelectList(db.Manufacturers, "Id", "Name", license.MenuId);
            ViewBag.CompanyId = new SelectList(db.Organizations, "Id", "Name", license.CompanyId);
            ViewBag.SupplierId = new SelectList(db.Supplier, "Id", "Name", license.SupplierId);
            return View(license);
        }

        // GET: Licenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            License license = db.License.Find(id);
            if (license == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuId = new SelectList(db.Manufacturers, "Id", "Name", license.MenuId);
            ViewBag.CompanyId = new SelectList(db.Organizations, "Id", "Name", license.CompanyId);
            ViewBag.SupplierId = new SelectList(db.Supplier, "Id", "Name", license.SupplierId);
            return View(license);
        }

        // POST: Licenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ProductKey,Seats,CompanyId,MenuId,LicenseName,LicenseEmail,SupplierId,OrderNumber,PurchaseCost,PurchaseDate,ExpirationDate,OrderNo,Notes,CreateDate,ActionDate")] License license)
        {
            license.ActionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(license).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuId = new SelectList(db.Manufacturers, "Id", "Name", license.MenuId);
            ViewBag.CompanyId = new SelectList(db.Organizations, "Id", "Name", license.CompanyId);
            ViewBag.SupplierId = new SelectList(db.Supplier, "Id", "Name", license.SupplierId);
            return View(license);
        }

        // GET: Licenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            License license = db.License.Find(id);
            if (license == null)
            {
                return HttpNotFound();
            }
            return View(license);
        }

        // POST: Licenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            License license = db.License.Find(id);
            db.License.Remove(license);
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
