using Melidya2.BLL;
using Melidya2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Melidya2.UI.Controllers
{
    public class ProfilController : Controller
    {
        CustomerBLL customerBLL = new CustomerBLL();
        // GET: Profil
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserProfile()
        {
            Customers customer = Session["Login"] as Customers;
            return View(customer);
        }

        public ActionResult EditProfile(string id)
        {
            Customers customer = customerBLL.GetCustomer(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult EditProfile(Customers customer)
        {
            Customers cust = customerBLL.GetCustomer(customer.CustomerID);
            cust.CustomerID = customer.CustomerID;
            cust.CustomerDemographics = customer.CustomerDemographics;
            cust.Country = customer.Country;
            cust.Fax = customer.Fax;
            cust.Password = customer.Password;
            cust.PostalCode = customer.PostalCode;
            cust.Region = customer.Region;
            cust.Phone = customer.Phone;
            cust.ContactName = customer.ContactName;
            cust.ContactTitle = customer.ContactTitle;
            cust.CompanyName = customer.CompanyName;
            cust.Address = customer.Address;
            cust.City = customer.City;

            customerBLL.Update(cust);
            return RedirectToAction("UserProfile");
        }
    }
}