using Melidya2.BLL;
using Melidya2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Melidya2.UI.Controllers
{
    public class HomeController : Controller
    {
        CustomerBLL customerBLL = new CustomerBLL();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customers cust)
        {
            Customers customer = customerBLL.GetCustomer(cust.CustomerID);
            if (customer!= null)
            {
                if (customer.Password == cust.Password)
                {
                    Session["Login"] = customer;
                    return RedirectToAction("Index","Order");
                }
                else
                {
                    return RedirectToAction("LoginHata");
                }
            }
            else
            {
                return RedirectToAction("LoginHata");
            }
        }
        public ActionResult LoginHata()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("Login");
            Session.Clear();
            return RedirectToAction("Login");
        }



    }
}