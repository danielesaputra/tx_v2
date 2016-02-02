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
    public class VENDOR_LOGINController : Controller
    {
        private TXContext db = new TXContext();

        // GET: VENDOR_LOGIN
        public ActionResult Index()
        {
            return View(db.VENDOR_LOGIN.ToList());
        }

        // GET: VENDOR_LOGIN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENDOR_LOGIN vENDOR_LOGIN = db.VENDOR_LOGIN.Find(id);
            if (vENDOR_LOGIN == null)
            {
                return HttpNotFound();
            }
            return View(vENDOR_LOGIN);
        }

        // GET: VENDOR_LOGIN/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VENDOR_LOGIN/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vendorlogin_ID,vendor_email,vendor_password")] VENDOR_LOGIN vENDOR_LOGIN)
        {
            if (ModelState.IsValid)
            {
                db.VENDOR_LOGIN.Add(vENDOR_LOGIN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vENDOR_LOGIN);
        }

        // GET: VENDOR_LOGIN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENDOR_LOGIN vENDOR_LOGIN = db.VENDOR_LOGIN.Find(id);
            if (vENDOR_LOGIN == null)
            {
                return HttpNotFound();
            }
            return View(vENDOR_LOGIN);
        }

        // POST: VENDOR_LOGIN/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vendorlogin_ID,vendor_email,vendor_password")] VENDOR_LOGIN vENDOR_LOGIN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vENDOR_LOGIN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vENDOR_LOGIN);
        }

        // GET: VENDOR_LOGIN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENDOR_LOGIN vENDOR_LOGIN = db.VENDOR_LOGIN.Find(id);
            if (vENDOR_LOGIN == null)
            {
                return HttpNotFound();
            }
            return View(vENDOR_LOGIN);
        }

        // POST: VENDOR_LOGIN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VENDOR_LOGIN vENDOR_LOGIN = db.VENDOR_LOGIN.Find(id);
            db.VENDOR_LOGIN.Remove(vENDOR_LOGIN);
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
