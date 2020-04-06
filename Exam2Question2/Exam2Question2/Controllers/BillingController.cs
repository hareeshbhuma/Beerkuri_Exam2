using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Exam2Question2.DAL;
using Exam2Question2.Models;

namespace Exam2Question2.Controllers
{
    public class BillingController : Controller
    {
        private OfficeContext db = new OfficeContext();

        // GET: Billing
        public ActionResult Index()
        {
            var billings = db.Billings.Include(b => b.Employee).Include(b => b.Project);
            return View(billings.ToList());
        }

        // GET: Billing/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billing billing = db.Billings.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            return View(billing);
        }

        // GET: Billing/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "LastName");
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Title");
            return View();
        }

        // POST: Billing/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BillingID,ProjectID,EmployeeID,Rate")] Billing billing)
        {
            if (ModelState.IsValid)
            {
                db.Billings.Add(billing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "LastName", billing.EmployeeID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Title", billing.ProjectID);
            return View(billing);
        }

        // GET: Billing/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billing billing = db.Billings.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "LastName", billing.EmployeeID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Title", billing.ProjectID);
            return View(billing);
        }

        // POST: Billing/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BillingID,ProjectID,EmployeeID,Rate")] Billing billing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "LastName", billing.EmployeeID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Title", billing.ProjectID);
            return View(billing);
        }

        // GET: Billing/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billing billing = db.Billings.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            return View(billing);
        }

        // POST: Billing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Billing billing = db.Billings.Find(id);
            db.Billings.Remove(billing);
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
