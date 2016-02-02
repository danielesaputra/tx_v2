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
    public class CUSTOMER_DATAController : Controller
    {
        private TXContext db = new TXContext();

        // GET: CUSTOMER_DATA
        public ActionResult Index()
        {
            var cUSTOMER_DATA = db.CUSTOMER_DATA.Include(c => c.CUSTOMER_LOGIN);
            return View(cUSTOMER_DATA.ToList());
        }

        // GET: CUSTOMER_DATA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER_DATA cUSTOMER_DATA = db.CUSTOMER_DATA.Find(id);
            if (cUSTOMER_DATA == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER_DATA);
        }

        // GET: CUSTOMER_DATA/Create
        public ActionResult Create()
        {
            ViewBag.customerlogin_ID = new SelectList(db.CUSTOMER_LOGIN, "customerlogin_ID", "customer_email");
            return View();
        }

        // POST: CUSTOMER_DATA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customerdata_ID,customerlogin_ID,customer_firstname,customer_lastname,customer_birthdate,customer_phone,customer_address,customer_facebook,customer_balance,customer_rewardpt")] CUSTOMER_DATA cUSTOMER_DATA)
        {
            if (ModelState.IsValid)
            {
                db.CUSTOMER_DATA.Add(cUSTOMER_DATA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customerlogin_ID = new SelectList(db.CUSTOMER_LOGIN, "customerlogin_ID", "customer_email", cUSTOMER_DATA.customerlogin_ID);
            return View(cUSTOMER_DATA);
        }

        // GET: CUSTOMER_DATA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER_DATA cUSTOMER_DATA = db.CUSTOMER_DATA.Find(id);
            if (cUSTOMER_DATA == null)
            {
                return HttpNotFound();
            }
            ViewBag.customerlogin_ID = new SelectList(db.CUSTOMER_LOGIN, "customerlogin_ID", "customer_email", cUSTOMER_DATA.customerlogin_ID);
            return View(cUSTOMER_DATA);
        }

        // POST: CUSTOMER_DATA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customerdata_ID,customerlogin_ID,customer_firstname,customer_lastname,customer_birthdate,customer_phone,customer_address,customer_facebook,customer_balance,customer_rewardpt")] CUSTOMER_DATA cUSTOMER_DATA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUSTOMER_DATA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customerlogin_ID = new SelectList(db.CUSTOMER_LOGIN, "customerlogin_ID", "customer_email", cUSTOMER_DATA.customerlogin_ID);
            return View(cUSTOMER_DATA);
        }

        // GET: CUSTOMER_DATA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER_DATA cUSTOMER_DATA = db.CUSTOMER_DATA.Find(id);
            if (cUSTOMER_DATA == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER_DATA);
        }

        // POST: CUSTOMER_DATA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CUSTOMER_DATA cUSTOMER_DATA = db.CUSTOMER_DATA.Find(id);
            db.CUSTOMER_DATA.Remove(cUSTOMER_DATA);
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
