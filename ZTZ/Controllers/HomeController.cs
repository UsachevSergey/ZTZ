using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZTZ.Models;

namespace ZTZ.Controllers
{
    public class HomeController : Controller
    {
        ContextDB CDB = new ContextDB();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
           return View();
        }
        [HttpPost]
        public ActionResult Register(Accounts acc)
        {
            acc.Id = Guid.NewGuid();
            CDB.Accounts.Add(acc);
            CDB.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login (string Name,string Password)
        { 
            Accounts ac = CDB.Accounts.SingleOrDefault(s => s.Name == Name);
            
                if (ac.Password == Password)
            {
                Session["Id_user"] = ac.Id;
                Session["Name"] = ac.Name;
                
                //
                //Сохраняет даные в куки
                //
                 
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Exit()
        {
            Session["Id_user"] = null;
            Session["Name"] = null;
           return  RedirectToAction("Index");
        }


    }
}