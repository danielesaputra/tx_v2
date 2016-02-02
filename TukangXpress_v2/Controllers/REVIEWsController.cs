using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TukangXpress_v2.DAL;
using TukangXpress_v2.Models;

namespace TukangXpress_v2.Controllers
{
    public class REVIEWsController : Controller
    {
        private TXContext db = new TXContext();

        // GET: REVIEWs
        public ActionResult Index()
        {
            var rEVIEW = db.REVIEW.Include(r => r.PROJECT_MASTER).Include(r => r.VENDOR_DATA);
            return View(rEVIEW.ToList());
        }

        // GET: REVIEWs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REVIEW rEVIEW = db.REVIEW.Find(id);
            if (rEVIEW == null)
            {
                return HttpNotFound();
            }
            return View(rEVIEW);
        }

        // GET: REVIEWs/Create
        public ActionResult Create()
        {
            ViewBag.project_ID = new SelectList(db.PROJECT_MASTER, "project_ID", "project_category");
            ViewBag.vendordata_ID = new SelectList(db.VENDOR_DATA, "vendordata_ID", "vendor_name");
            return View();
        }

        // POST: REVIEWs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "review_ID,vendordata_ID,project_ID,details,point")] REVIEW rEVIEW)
        {
            if (ModelState.IsValid)
            {
                db.REVIEW.Add(rEVIEW);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.project_ID = new SelectList(db.PROJECT_MASTER, "project_ID", "project_category", rEVIEW.project_ID);
            ViewBag.vendordata_ID = new SelectList(db.VENDOR_DATA, "vendordata_ID", "vendor_name", rEVIEW.vendordata_ID);
            return View(rEVIEW);
        }

        // GET: REVIEWs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REVIEW rEVIEW = db.REVIEW.Find(id);
            if (rEVIEW == null)
            {
                return HttpNotFound();
            }
            ViewBag.project_ID = new SelectList(db.PROJECT_MASTER, "project_ID", "project_category", rEVIEW.project_ID);
            ViewBag.vendordata_ID = new SelectList(db.VENDOR_DATA, "vendordata_ID", "vendor_name", rEVIEW.vendordata_ID);
            return View(rEVIEW);
        }

        // POST: REVIEWs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "review_ID,vendordata_ID,project_ID,details,point")] REVIEW rEVIEW)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEVIEW).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.project_ID = new SelectList(db.PROJECT_MASTER, "project_ID", "project_category", rEVIEW.project_ID);
            ViewBag.vendordata_ID = new SelectList(db.VENDOR_DATA, "vendordata_ID", "vendor_name", rEVIEW.vendordata_ID);
            return View(rEVIEW);
        }

        // GET: REVIEWs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REVIEW rEVIEW = db.REVIEW.Find(id);
            if (rEVIEW == null)
            {
                return HttpNotFound();
            }
            return View(rEVIEW);
        }

        // POST: REVIEWs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            REVIEW rEVIEW = db.REVIEW.Find(id);
            db.REVIEW.Remove(rEVIEW);
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
