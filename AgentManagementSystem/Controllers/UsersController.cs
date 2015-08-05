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
    public class UsersController : Controller
    {
        private DbEntities1 db = new DbEntities1();

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        // GET: Users/Details/5
        [HttpPost]
        public ActionResult Login(User obj)
        {
            try
            {
                var user = db.Users.First(y=>y.EmailId==obj.EmailId && y.Password==obj.Password);

            }catch(Exception e)
            {
                return RedirectToAction("Index", "Users");
            }

            return RedirectToAction("Index", "Ports");
        }
    }
}
