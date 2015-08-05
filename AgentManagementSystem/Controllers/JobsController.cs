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
    public class JobsController : Controller
    {
        // GET: Jobs
        DbEntities1 db = new DbEntities1();

        public ActionResult Index()
        {
            var quotations = db.Quotations.Where(y=>y.Status=="active").Include(q => q.Comodity).Include(q => q.Packing).Include(q => q.Port).Include(q => q.Port1).Include(q => q.Shipper).Include(q => q.Consignee);
            return View(quotations.ToList());
        }

        public ActionResult DiscardJob(int id)
        {
            var obj = db.Quotations.Find(id);
            obj.Status = "inactive";

            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}