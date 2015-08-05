using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgentManagementSystem.Models;

namespace AgentManagementSystem.Controllers
{
    public class ServiceForQuotationsController : Controller
    {
        private DbEntities1 db = new DbEntities1();

        // GET: ServiceForQuotations
        public ActionResult Index()
        {
            var serviceForQuotations = db.ServiceForQuotations.Include(s => s.Quotation).Include(s => s.Service);
            return View(serviceForQuotations.ToList());
        }

        // GET: ServiceForQuotations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceForQuotation serviceForQuotation = db.ServiceForQuotations.Find(id);
            if (serviceForQuotation == null)
            {
                return HttpNotFound();
            }
            return View(serviceForQuotation);
        }

        // GET: ServiceForQuotations/Create
        public ActionResult Create()
        {
            ViewBag.QuotationId = new SelectList(db.Quotations, "Id", "FlightNo");
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Code");
            return View();
        }

        // POST: ServiceForQuotations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ServiceId,Quantity,UnitPrice,QuotationId")] ServiceForQuotation serviceForQuotation)
        {
            if (ModelState.IsValid)
            {
                db.ServiceForQuotations.Add(serviceForQuotation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuotationId = new SelectList(db.Quotations, "Id", "FlightNo", serviceForQuotation.QuotationId);
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Code", serviceForQuotation.ServiceId);
            return View(serviceForQuotation);
        }

        // GET: ServiceForQuotations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceForQuotation serviceForQuotation = db.ServiceForQuotations.Find(id);
            if (serviceForQuotation == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuotationId = new SelectList(db.Quotations, "Id", "FlightNo", serviceForQuotation.QuotationId);
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Code", serviceForQuotation.ServiceId);
            return View(serviceForQuotation);
        }

        // POST: ServiceForQuotations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ServiceId,Quantity,UnitPrice,QuotationId")] ServiceForQuotation serviceForQuotation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceForQuotation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuotationId = new SelectList(db.Quotations, "Id", "FlightNo", serviceForQuotation.QuotationId);
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Code", serviceForQuotation.ServiceId);
            return View(serviceForQuotation);
        }

        // GET: ServiceForQuotations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceForQuotation serviceForQuotation = db.ServiceForQuotations.Find(id);
            if (serviceForQuotation == null)
            {
                return HttpNotFound();
            }
            return View(serviceForQuotation);
        }

        // POST: ServiceForQuotations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceForQuotation serviceForQuotation = db.ServiceForQuotations.Find(id);
            db.ServiceForQuotations.Remove(serviceForQuotation);
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
