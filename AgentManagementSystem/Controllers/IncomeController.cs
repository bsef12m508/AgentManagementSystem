using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgentManagementSystem.Models;

namespace AgentManagementSystem.Controllers
{
    public class IncomeController : Controller
    {
        // GET: Income
        DbEntities1 db = new DbEntities1();

        public ActionResult Index()
        {
            //ViewBag.Expenses = db.Expenses.ToList();
            //ViewBag.Quotations = db.Quotations.ToList();

            ViewBag.TotalIncome = db.Quotations.Sum(y=>y.PayedAmount);
            ViewBag.TotalSalaries = db.Salaries.Sum(y => y.PaidAmount);
            ViewBag.TotalExpenses = db.Expenses.Sum(y => y.Amount);
            return View();
        }

    }
}