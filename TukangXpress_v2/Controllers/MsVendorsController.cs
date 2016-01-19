using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TukangXpress_v2.Models;

namespace TukangXpress_v2.Controllers
{
    public class MsVendorsController : Controller
    {
        private MsVendorDBContext db = new MsVendorDBContext();

        // GET: MsVendors
        public ActionResult Index(string searchString)
        {
            var email = from m in db.MsVendors
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                email = email.Where(s => s.Vendor_Email.Contains(searchString));
            }

            return View(email);
        }

        // GET: MsVendors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MsVendor msVendor = db.MsVendors.Find(id);
            if (msVendor == null)
            {
                return HttpNotFound();
            }
            return View(msVendor);
        }

        // GET: MsVendors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MsVendors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Vendor_ID,Vendor_Email,Vendor_Balance,Password")] MsVendor msVendor)
        {
            if (ModelState.IsValid)
            {
                db.MsVendors.Add(msVendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(msVendor);
        }

        // GET: MsVendors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MsVendor msVendor = db.MsVendors.Find(id);
            if (msVendor == null)
            {
                return HttpNotFound();
            }
            return View(msVendor);
        }

        // POST: MsVendors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Vendor_ID,Vendor_Email,Vendor_Balance,Password")] MsVendor msVendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(msVendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(msVendor);
        }

        // GET: MsVendors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MsVendor msVendor = db.MsVendors.Find(id);
            if (msVendor == null)
            {
                return HttpNotFound();
            }
            return View(msVendor);
        }

        // POST: MsVendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MsVendor msVendor = db.MsVendors.Find(id);
            db.MsVendors.Remove(msVendor);
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
