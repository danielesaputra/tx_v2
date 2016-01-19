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
    public class CustomerDatasController : Controller
    {
        private CustomerDataDBContext db = new CustomerDataDBContext();

        // GET: CustomerDatas
        public ActionResult Index()
        {
            return View(db.CustomerDatas.ToList());
        }

        // GET: CustomerDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerData customerData = db.CustomerDatas.Find(id);
            if (customerData == null)
            {
                return HttpNotFound();
            }
            return View(customerData);
        }

        // GET: CustomerDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Customer_Data_ID,Customer_ID,Facebook_ID,First_Name,Last_Name,Birth_Date,Address,Phone")] CustomerData customerData)
        {
            if (ModelState.IsValid)
            {
                db.CustomerDatas.Add(customerData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerData);
        }

        // GET: CustomerDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerData customerData = db.CustomerDatas.Find(id);
            if (customerData == null)
            {
                return HttpNotFound();
            }
            return View(customerData);
        }

        // POST: CustomerDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Customer_Data_ID,Customer_ID,Facebook_ID,First_Name,Last_Name,Birth_Date,Address,Phone")] CustomerData customerData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerData);
        }

        // GET: CustomerDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerData customerData = db.CustomerDatas.Find(id);
            if (customerData == null)
            {
                return HttpNotFound();
            }
            return View(customerData);
        }

        // POST: CustomerDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerData customerData = db.CustomerDatas.Find(id);
            db.CustomerDatas.Remove(customerData);
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
