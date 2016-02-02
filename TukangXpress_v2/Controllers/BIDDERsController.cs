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
    public class BIDDERsController : Controller
    {
        private TXContext db = new TXContext();

        // GET: BIDDERs
        public ActionResult Index()
        {
            var bIDDER = db.BIDDER.Include(b => b.PROJECT_MASTER).Include(b => b.VENDOR_DATA);
            return View(bIDDER.ToList());
        }

        // GET: BIDDERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BIDDER bIDDER = db.BIDDER.Find(id);
            if (bIDDER == null)
            {
                return HttpNotFound();
            }
            return View(bIDDER);
        }

        // GET: BIDDERs/Create
        public ActionResult Create()
        {
            ViewBag.project_ID = new SelectList(db.PROJECT_MASTER, "project_ID", "project_category");
            ViewBag.vendordata_ID = new SelectList(db.VENDOR_DATA, "vendordata_ID", "vendor_name");
            return View();
        }

        // POST: BIDDERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bidder_ID,vendordata_ID,project_ID,ammount,winning_status")] BIDDER bIDDER)
        {
            if (ModelState.IsValid)
            {
                db.BIDDER.Add(bIDDER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.project_ID = new SelectList(db.PROJECT_MASTER, "project_ID", "project_category", bIDDER.project_ID);
            ViewBag.vendordata_ID = new SelectList(db.VENDOR_DATA, "vendordata_ID", "vendor_name", bIDDER.vendordata_ID);
            return View(bIDDER);
        }

        // GET: BIDDERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BIDDER bIDDER = db.BIDDER.Find(id);
            if (bIDDER == null)
            {
                return HttpNotFound();
            }
            ViewBag.project_ID = new SelectList(db.PROJECT_MASTER, "project_ID", "project_category", bIDDER.project_ID);
            ViewBag.vendordata_ID = new SelectList(db.VENDOR_DATA, "vendordata_ID", "vendor_name", bIDDER.vendordata_ID);
            return View(bIDDER);
        }

        // POST: BIDDERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bidder_ID,vendordata_ID,project_ID,ammount,winning_status")] BIDDER bIDDER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bIDDER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.project_ID = new SelectList(db.PROJECT_MASTER, "project_ID", "project_category", bIDDER.project_ID);
            ViewBag.vendordata_ID = new SelectList(db.VENDOR_DATA, "vendordata_ID", "vendor_name", bIDDER.vendordata_ID);
            return View(bIDDER);
        }

        // GET: BIDDERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BIDDER bIDDER = db.BIDDER.Find(id);
            if (bIDDER == null)
            {
                return HttpNotFound();
            }
            return View(bIDDER);
        }

        // POST: BIDDERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BIDDER bIDDER = db.BIDDER.Find(id);
            db.BIDDER.Remove(bIDDER);
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
