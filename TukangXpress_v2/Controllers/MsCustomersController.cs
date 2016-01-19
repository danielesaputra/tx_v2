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
    public class MsCustomersController : Controller
    {
        private MsCustomerDBContext db = new MsCustomerDBContext();

        // GET: MsCustomers
        public ActionResult Index(string searchString)
        {
            var email = from m in db.MsCustomers
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                email = email.Where(s => s.Customer_Email.Contains(searchString));
            }

            return View(email);
        }

        // GET: MsCustomers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MsCustomer msCustomer = db.MsCustomers.Find(id);
            if (msCustomer == null)
            {
                return HttpNotFound();
            }
            return View(msCustomer);
        }

        // GET: MsCustomers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MsCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Customer_ID,Customer_Email,Customer_Balance,Reward_Point,Password")] MsCustomer msCustomer)
        {
            if (ModelState.IsValid)
            {
                db.MsCustomers.Add(msCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(msCustomer);
        }

        // GET: MsCustomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MsCustomer msCustomer = db.MsCustomers.Find(id);
            if (msCustomer == null)
            {
                return HttpNotFound();
            }
            return View(msCustomer);
        }

        // POST: MsCustomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Customer_ID,Customer_Email,Customer_Balance,Reward_Point,Password")] MsCustomer msCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(msCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(msCustomer);
        }

        // GET: MsCustomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MsCustomer msCustomer = db.MsCustomers.Find(id);
            if (msCustomer == null)
            {
                return HttpNotFound();
            }
            return View(msCustomer);
        }

        // POST: MsCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MsCustomer msCustomer = db.MsCustomers.Find(id);
            db.MsCustomers.Remove(msCustomer);
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
