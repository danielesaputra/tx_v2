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
    public class VENDOR_DATAController : Controller
    {
        private TXContext db = new TXContext();

        // GET: VENDOR_DATA
        public ActionResult Index()
        {
            var vENDOR_DATA = db.VENDOR_DATA.Include(v => v.VENDOR_LOGIN);
            return View(vENDOR_DATA.ToList());
        }

        // GET: VENDOR_DATA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENDOR_DATA vENDOR_DATA = db.VENDOR_DATA.Find(id);
            if (vENDOR_DATA == null)
            {
                return HttpNotFound();
            }
            return View(vENDOR_DATA);
        }

        // GET: VENDOR_DATA/Create
        public ActionResult Create()
        {
            ViewBag.vendorlogin_ID = new SelectList(db.VENDOR_LOGIN, "vendorlogin_ID", "vendor_email");
            return View();
        }

        // POST: VENDOR_DATA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vendordata_ID,vendorlogin_ID,vendor_name,vendor_ownername,vendor_phone,vendor_address,vendor_balance")] VENDOR_DATA vENDOR_DATA)
        {
            if (ModelState.IsValid)
            {
                db.VENDOR_DATA.Add(vENDOR_DATA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.vendorlogin_ID = new SelectList(db.VENDOR_LOGIN, "vendorlogin_ID", "vendor_email", vENDOR_DATA.vendorlogin_ID);
            return View(vENDOR_DATA);
        }

        // GET: VENDOR_DATA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENDOR_DATA vENDOR_DATA = db.VENDOR_DATA.Find(id);
            if (vENDOR_DATA == null)
            {
                return HttpNotFound();
            }
            ViewBag.vendorlogin_ID = new SelectList(db.VENDOR_LOGIN, "vendorlogin_ID", "vendor_email", vENDOR_DATA.vendorlogin_ID);
            return View(vENDOR_DATA);
        }

        // POST: VENDOR_DATA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vendordata_ID,vendorlogin_ID,vendor_name,vendor_ownername,vendor_phone,vendor_address,vendor_balance")] VENDOR_DATA vENDOR_DATA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vENDOR_DATA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.vendorlogin_ID = new SelectList(db.VENDOR_LOGIN, "vendorlogin_ID", "vendor_email", vENDOR_DATA.vendorlogin_ID);
            return View(vENDOR_DATA);
        }

        // GET: VENDOR_DATA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENDOR_DATA vENDOR_DATA = db.VENDOR_DATA.Find(id);
            if (vENDOR_DATA == null)
            {
                return HttpNotFound();
            }
            return View(vENDOR_DATA);
        }

        // POST: VENDOR_DATA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VENDOR_DATA vENDOR_DATA = db.VENDOR_DATA.Find(id);
            db.VENDOR_DATA.Remove(vENDOR_DATA);
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
