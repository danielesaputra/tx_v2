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
    public class TRANS_DETAILSController : Controller
    {
        private TXContext db = new TXContext();

        // GET: TRANS_DETAILS
        public ActionResult Index()
        {
            var tRANS_DETAILS = db.TRANS_DETAILS.Include(t => t.PROJECT_MASTER).Include(t => t.VENDOR_DATA);
            return View(tRANS_DETAILS.ToList());
        }

        // GET: TRANS_DETAILS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANS_DETAILS tRANS_DETAILS = db.TRANS_DETAILS.Find(id);
            if (tRANS_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(tRANS_DETAILS);
        }

        // GET: TRANS_DETAILS/Create
        public ActionResult Create()
        {
            ViewBag.project_ID = new SelectList(db.PROJECT_MASTER, "project_ID", "project_category");
            ViewBag.vendordata_ID = new SelectList(db.VENDOR_DATA, "vendordata_ID", "vendor_name");
            return View();
        }

        // POST: TRANS_DETAILS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "trans_ID,vendordata_ID,project_ID")] TRANS_DETAILS tRANS_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.TRANS_DETAILS.Add(tRANS_DETAILS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.project_ID = new SelectList(db.PROJECT_MASTER, "project_ID", "project_category", tRANS_DETAILS.project_ID);
            ViewBag.vendordata_ID = new SelectList(db.VENDOR_DATA, "vendordata_ID", "vendor_name", tRANS_DETAILS.vendordata_ID);
            return View(tRANS_DETAILS);
        }

        // GET: TRANS_DETAILS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANS_DETAILS tRANS_DETAILS = db.TRANS_DETAILS.Find(id);
            if (tRANS_DETAILS == null)
            {
                return HttpNotFound();
            }
            ViewBag.project_ID = new SelectList(db.PROJECT_MASTER, "project_ID", "project_category", tRANS_DETAILS.project_ID);
            ViewBag.vendordata_ID = new SelectList(db.VENDOR_DATA, "vendordata_ID", "vendor_name", tRANS_DETAILS.vendordata_ID);
            return View(tRANS_DETAILS);
        }

        // POST: TRANS_DETAILS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "trans_ID,vendordata_ID,project_ID")] TRANS_DETAILS tRANS_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRANS_DETAILS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.project_ID = new SelectList(db.PROJECT_MASTER, "project_ID", "project_category", tRANS_DETAILS.project_ID);
            ViewBag.vendordata_ID = new SelectList(db.VENDOR_DATA, "vendordata_ID", "vendor_name", tRANS_DETAILS.vendordata_ID);
            return View(tRANS_DETAILS);
        }

        // GET: TRANS_DETAILS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANS_DETAILS tRANS_DETAILS = db.TRANS_DETAILS.Find(id);
            if (tRANS_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(tRANS_DETAILS);
        }

        // POST: TRANS_DETAILS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRANS_DETAILS tRANS_DETAILS = db.TRANS_DETAILS.Find(id);
            db.TRANS_DETAILS.Remove(tRANS_DETAILS);
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
