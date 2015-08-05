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
    public class QuotationsController : Controller
    {
        private DbEntities1 db = new DbEntities1();

        // GET: Quotations
        public ActionResult Index()
        {
            var quotations = db.Quotations.Where(q=>q.Status=="inactive").Include(q => q.Comodity).Include(q => q.Packing).Include(q => q.Port).Include(q => q.Port1).Include(q => q.Shipper).Include(q => q.Consignee);
            return View(quotations.ToList());
        }

        // GET: Quotations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quotation quotation = db.Quotations.Find(id);
            if (quotation == null)
            {
                return HttpNotFound();
            }

            List<ServiceForQuotation> list = db.ServiceForQuotations.Where(y => y.QuotationId == id).ToList();
            ViewBag.Srv = list;
            return View(quotation);
        }

        // GET: Quotations/Create
        public ActionResult Create()
        {
            ViewBag.ComodityId = new SelectList(db.Comodities, "Id", "Title");
            ViewBag.PackingId = new SelectList(db.Packings, "Id", "Title");
            ViewBag.LoadingPort = new SelectList(db.Ports, "Id", "PortName");
            ViewBag.DischargePort = new SelectList(db.Ports, "Id", "PortName");
            ViewBag.ShipperId = new SelectList(db.Shippers, "Id", "PersonName");
            ViewBag.ConsigneeId = new SelectList(db.Consignees, "Id", "PersonName");
            ViewBag.ServiceId = db.Services.ToList();
            return View();
        }

        // POST: Quotations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,ShipperId,ComodityId,Quantity,PackingId,Weight,LoadingPort,DischargePort,FlightNo,SailingDate,ArrivalDate,Status,PayedAmount,ConsigneeId")] Quotation quotation)
        {
            if (ModelState.IsValid)
            {
                db.Quotations.Add(quotation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComodityId = new SelectList(db.Comodities, "Id", "Title", quotation.ComodityId);
            ViewBag.PackingId = new SelectList(db.Packings, "Id", "Title", quotation.PackingId);
            ViewBag.LoadingPort = new SelectList(db.Ports, "Id", "PortName", quotation.LoadingPort);
            ViewBag.DischargePort = new SelectList(db.Ports, "Id", "PortName", quotation.DischargePort);
            ViewBag.ShipperId = new SelectList(db.Shippers, "Id", "PersonName", quotation.ShipperId);
            ViewBag.ConsigneeId = new SelectList(db.Consignees, "Id", "PersonName", quotation.ConsigneeId);
            return View(quotation);
        }

        //----------------------->>>>>Add quotation and services here.....

        public JsonResult AddQuotation(srv[] ar, quotation ob)
        {
            if (ModelState.IsValid)
            {
                return this.Json("-------", JsonRequestBehavior.AllowGet);
            }
            try
            {
                Quotation obj = new Quotation();
                obj.Date = ob.date;
                obj.ShipperId = ob.shipperid;
                obj.ComodityId = ob.comodityid;
                obj.Quantity = ob.quantity;
                obj.PackingId = ob.packingid;
                obj.Weight = ob.weight;
                obj.LoadingPort = ob.loadingport;
                obj.DischargePort = ob.dischargeport;
                obj.FlightNo = ob.flightno;
                obj.SailingDate = ob.sailingdate;
                obj.ArrivalDate = ob.arrivaldate;
                obj.ConsigneeId = ob.consigneeid;
                obj.Status = "inactive";
                obj.PayedAmount = 0;

                db.Quotations.Add(obj);
                db.SaveChanges();

                int id = obj.Id;

                ServiceForQuotation sample = new ServiceForQuotation();

                foreach (var a in ar)
                {
                    sample.Quantity = a.quantity;
                    sample.UnitPrice = a.price;
                    sample.QuotationId = id;
                    sample.ServiceId = a.id;
                    db.ServiceForQuotations.Add(sample);
                    db.SaveChanges();
                }
                return this.Json("success", JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return this.Json("-------", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quotation quotation = db.Quotations.Find(id);
            if (quotation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComodityId = new SelectList(db.Comodities, "Id", "Title", quotation.ComodityId);
            ViewBag.PackingId = new SelectList(db.Packings, "Id", "Title", quotation.PackingId);
            ViewBag.LoadingPort = new SelectList(db.Ports, "Id", "PortName", quotation.LoadingPort);
            ViewBag.DischargePort = new SelectList(db.Ports, "Id", "PortName", quotation.DischargePort);
            ViewBag.ShipperId = new SelectList(db.Shippers, "Id", "PersonName", quotation.ShipperId);
            ViewBag.ConsigneeId = new SelectList(db.Consignees, "Id", "PersonName", quotation.ConsigneeId);
            ViewBag.ServiceId = db.Services.ToList();
            ViewBag.ServicesForQuotation = db.ServiceForQuotations.Where(y => y.QuotationId == id).Select(y=>y);
            return View(quotation);
        }

        public ActionResult EditJob(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quotation quotation = db.Quotations.Find(id);
            if (quotation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComodityId = new SelectList(db.Comodities, "Id", "Title", quotation.ComodityId);
            ViewBag.PackingId = new SelectList(db.Packings, "Id", "Title", quotation.PackingId);
            ViewBag.LoadingPort = new SelectList(db.Ports, "Id", "PortName", quotation.LoadingPort);
            ViewBag.DischargePort = new SelectList(db.Ports, "Id", "PortName", quotation.DischargePort);
            ViewBag.ShipperId = new SelectList(db.Shippers, "Id", "PersonName", quotation.ShipperId);
            ViewBag.ConsigneeId = new SelectList(db.Consignees, "Id", "PersonName", quotation.ConsigneeId);
            ViewBag.ServiceId = db.Services.ToList();
            ViewBag.ServicesForQuotation = db.ServiceForQuotations.Where(y => y.QuotationId == id).Select(y => y);
            return View(quotation);
        }

        public JsonResult EditQuotation(srv[] ar, quotation ob)
        {
            try
            {
                Quotation obj = new Quotation();
                obj.Id = ob.id;
                obj.Date = ob.date;
                obj.ShipperId = ob.shipperid;
                obj.ComodityId = ob.comodityid;
                obj.Quantity = ob.quantity;
                obj.PackingId = ob.packingid;
                obj.Weight = ob.weight;
                obj.LoadingPort = ob.loadingport;
                obj.DischargePort = ob.dischargeport;
                obj.FlightNo = ob.flightno;
                obj.SailingDate = ob.sailingdate;
                obj.ArrivalDate = ob.arrivaldate;
                obj.ConsigneeId = ob.consigneeid;
                obj.Status = ob.status;
                obj.PayedAmount = ob.payedamount;

                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();

                int id = obj.Id;

                var list = db.ServiceForQuotations.Where(x => x.QuotationId == id).Select(x => x).ToList();

                foreach (var a in list)
                {
                    db.ServiceForQuotations.Remove(a);
                    db.SaveChanges();
                }

                ServiceForQuotation sample = new ServiceForQuotation();
                foreach (var a in ar)
                {
                    sample.Quantity = a.quantity;
                    sample.UnitPrice = a.price;
                    sample.QuotationId = id;
                    sample.ServiceId = a.id;
                    db.ServiceForQuotations.Add(sample);
                    db.SaveChanges();
                }
                return this.Json("success", JsonRequestBehavior.AllowGet);
            }catch(Exception e)
            {
                return this.Json("----",JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Quotations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quotation quotation = db.Quotations.Find(id);
            List<ServiceForQuotation> list = db.ServiceForQuotations.Where(y => y.QuotationId == id).ToList();
            ViewBag.Srv = list;
            if (quotation == null)
            {
                return HttpNotFound();
            }
            return View(quotation);
        }

        // POST: Quotations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quotation quotation = db.Quotations.Find(id);
            db.Quotations.Remove(quotation);
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

        public ActionResult MakeJob(int id)
        {
            var obj = db.Quotations.Find(id);
            List<ServiceForQuotation> list = db.ServiceForQuotations.Where(y => y.QuotationId == id).ToList();
            ViewBag.Srv = list;


            int total = 0;
            foreach(var a in list)
            {
                int c = (int)a.Quantity;
                total = total+ ((int)a.Quantity * (int)a.UnitPrice);
            }

            ViewBag.Total = total;
            return View(obj);
        }

        public ActionResult MakePayment(int id, int amount)
        {
            var obj = db.Quotations.Find(id);
            obj.Status = "active";
            obj.PayedAmount = obj.PayedAmount + amount;

            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index","Jobs");
        }
    }
}
public class srv
{
    public int serviceid { get; set; }
    public int id { get; set; }
    public int price { get; set; }
    public int quantity { get; set; }
}

public class quotation
{
    public int id { get; set; }
    public DateTime date { get; set; }
    public int shipperid { get; set; }
    public int consigneeid { get; set; }
    public int comodityid { get; set; }
    public int quantity { get; set; }
    public int packingid { get; set; }
    public int weight { get; set; }
    public int loadingport { get; set; }
    public int dischargeport { get; set; }
    public string flightno { get; set; }
    public DateTime sailingdate { get; set; }
    public DateTime arrivaldate { get; set; }
    public string status { get; set; }
    public int payedamount { get; set; }
}