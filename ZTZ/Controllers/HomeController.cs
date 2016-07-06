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
            if (CDB.Accounts.Any(s => s.Name == acc.Name))
            {
                ViewBag.os = "Логин занят";
                return View();
            }
            acc.Id = Guid.NewGuid();
            CDB.Accounts.Add(acc);
            CDB.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult info()
        {
            return View();
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

        public ActionResult MyOrd() {

            ViewData["items"] = new[]
           {
                new SelectListItem{ Text = "Сформирован", Value = "Сформирован" },
                new SelectListItem { Text = "В обработке",Value = "В обработке"},
                new SelectListItem {Text = "Выполнен", Value = "Выполнен" },
               
            };
            Guid g = (Guid)Session["Id_user"];
            return View(CDB.Orders.Where(w=>w.Account_Id== g ).ToList());
        }

        public ActionResult Product()
        {
          return  View(CDB.Products.ToList());
        }
        [HttpGet]
        public ActionResult CreateOrder()
        { 
            Orders o = new Orders();
            Guid g = (Guid)Session["Id_user"];
            o.Account_Id = g;
            o.Status = "Сформирован";
            o.Date = DateTime.Now;
            if (CDB.Orders.Count(s => s.Account_Id ==g) > 0) {
                o.Number = CDB.Orders.Where(s => s.Account_Id ==g).Max(d => d.Number) + 1;
            }
            else { o.Number = 1; }
            return View(o);
        }
        [HttpPost]
        public ActionResult CreateOrder(Orders ord, int Id_prod ,Guid Numb,int Count_item)
        {
            return View();
        }





        //Частички
        public ActionResult Additemalax()
        {
            return PartialView();
        }

    }
}