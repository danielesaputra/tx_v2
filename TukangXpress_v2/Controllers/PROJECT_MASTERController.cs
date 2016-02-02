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
    public class PROJECT_MASTERController : Controller
    {
        private TXContext db = new TXContext();

        // GET: PROJECT_MASTER
        public ActionResult Index()
        {
            var pROJECT_MASTER = db.PROJECT_MASTER.Include(p => p.CUSTOMER_DATA);
            return View(pROJECT_MASTER.ToList());
        }

        // GET: PROJECT_MASTER/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJECT_MASTER pROJECT_MASTER = db.PROJECT_MASTER.Find(id);
            if (pROJECT_MASTER == null)
            {
                return HttpNotFound();
            }
            return View(pROJECT_MASTER);
        }

        // GET: PROJECT_MASTER/Create
        public ActionResult Create()
        {
            ViewBag.customerdata_ID = new SelectList(db.CUSTOMER_DATA, "customerdata_ID", "customer_firstname");
            return View();
        }

        // POST: PROJECT_MASTER/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "project_ID,customerdata_ID,project_category,project_duedate,project_additionalinfo")] PROJECT_MASTER pROJECT_MASTER)
        {
            if (ModelState.IsValid)
            {
                db.PROJECT_MASTER.Add(pROJECT_MASTER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customerdata_ID = new SelectList(db.CUSTOMER_DATA, "customerdata_ID", "customer_firstname", pROJECT_MASTER.customerdata_ID);
            return View(pROJECT_MASTER);
        }

        // GET: PROJECT_MASTER/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJECT_MASTER pROJECT_MASTER = db.PROJECT_MASTER.Find(id);
            if (pROJECT_MASTER == null)
            {
                return HttpNotFound();
            }
            ViewBag.customerdata_ID = new SelectList(db.CUSTOMER_DATA, "customerdata_ID", "customer_firstname", pROJECT_MASTER.customerdata_ID);
            return View(pROJECT_MASTER);
        }

        // POST: PROJECT_MASTER/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "project_ID,customerdata_ID,project_category,project_duedate,project_additionalinfo")] PROJECT_MASTER pROJECT_MASTER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROJECT_MASTER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customerdata_ID = new SelectList(db.CUSTOMER_DATA, "customerdata_ID", "customer_firstname", pROJECT_MASTER.customerdata_ID);
            return View(pROJECT_MASTER);
        }

        // GET: PROJECT_MASTER/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJECT_MASTER pROJECT_MASTER = db.PROJECT_MASTER.Find(id);
            if (pROJECT_MASTER == null)
            {
                return HttpNotFound();
            }
            return View(pROJECT_MASTER);
        }

        // POST: PROJECT_MASTER/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROJECT_MASTER pROJECT_MASTER = db.PROJECT_MASTER.Find(id);
            db.PROJECT_MASTER.Remove(pROJECT_MASTER);
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
