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
    public class CateTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CateTypes
        public ActionResult Index()
        {
            return View(db.CateType.ToList());
        }

        // GET: CateTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CateType cateType = db.CateType.Find(id);
            if (cateType == null)
            {
                return HttpNotFound();
            }
            return View(cateType);
        }

        // GET: CateTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CateTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeId,Name,CreateDate,ActionDate")] CateType cateType)
        {
            cateType.CreateDate = DateTime.Now;
            cateType.ActionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.CateType.Add(cateType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cateType);
        }

        // GET: CateTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CateType cateType = db.CateType.Find(id);
            if (cateType == null)
            {
                return HttpNotFound();
            }
            return View(cateType);
        }

        // POST: CateTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeId,Name,CreateDate,ActionDate")] CateType cateType)
        {
            cateType.ActionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(cateType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cateType);
        }

        // GET: CateTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CateType cateType = db.CateType.Find(id);
            if (cateType == null)
            {
                return HttpNotFound();
            }
            return View(cateType);
        }

        // POST: CateTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CateType cateType = db.CateType.Find(id);
            db.CateType.Remove(cateType);
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
