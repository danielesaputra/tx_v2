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
    public class CUSTOMER_LOGINController : Controller
    {
        private TXContext db = new TXContext();

        // GET: CUSTOMER_LOGIN
        public ActionResult Index()
        {
            return View(db.CUSTOMER_LOGIN.ToList());
        }

        // GET: CUSTOMER_LOGIN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER_LOGIN cUSTOMER_LOGIN = db.CUSTOMER_LOGIN.Find(id);
            if (cUSTOMER_LOGIN == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER_LOGIN);
        }

        // GET: CUSTOMER_LOGIN/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CUSTOMER_LOGIN/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customerlogin_ID,customer_email,customer_password")] CUSTOMER_LOGIN cUSTOMER_LOGIN)
        {
            if (ModelState.IsValid)
            {
                db.CUSTOMER_LOGIN.Add(cUSTOMER_LOGIN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cUSTOMER_LOGIN);
        }

        // GET: CUSTOMER_LOGIN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER_LOGIN cUSTOMER_LOGIN = db.CUSTOMER_LOGIN.Find(id);
            if (cUSTOMER_LOGIN == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER_LOGIN);
        }

        // POST: CUSTOMER_LOGIN/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customerlogin_ID,customer_email,customer_password")] CUSTOMER_LOGIN cUSTOMER_LOGIN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUSTOMER_LOGIN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cUSTOMER_LOGIN);
        }

        // GET: CUSTOMER_LOGIN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER_LOGIN cUSTOMER_LOGIN = db.CUSTOMER_LOGIN.Find(id);
            if (cUSTOMER_LOGIN == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER_LOGIN);
        }

        // POST: CUSTOMER_LOGIN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CUSTOMER_LOGIN cUSTOMER_LOGIN = db.CUSTOMER_LOGIN.Find(id);
            db.CUSTOMER_LOGIN.Remove(cUSTOMER_LOGIN);
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
