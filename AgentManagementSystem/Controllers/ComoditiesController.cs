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
    public class ComoditiesController : Controller
    {
        private DbEntities1 db = new DbEntities1();

        // GET: Comodities
        public ActionResult Index()
        {
            return View(db.Comodities.ToList());
        }

        // GET: Comodities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comodity comodity = db.Comodities.Find(id);
            if (comodity == null)
            {
                return HttpNotFound();
            }
            return View(comodity);
        }

        // GET: Comodities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comodities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title")] Comodity comodity)
        {
            if (ModelState.IsValid)
            {
                db.Comodities.Add(comodity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comodity);
        }

        // GET: Comodities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comodity comodity = db.Comodities.Find(id);
            if (comodity == null)
            {
                return HttpNotFound();
            }
            return View(comodity);
        }

        // POST: Comodities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] Comodity comodity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comodity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comodity);
        }

        // GET: Comodities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comodity comodity = db.Comodities.Find(id);
            if (comodity == null)
            {
                return HttpNotFound();
            }
            return View(comodity);
        }

        // POST: Comodities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comodity comodity = db.Comodities.Find(id);
            db.Comodities.Remove(comodity);
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
