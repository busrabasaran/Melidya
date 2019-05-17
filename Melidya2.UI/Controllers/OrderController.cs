using Melidya2.BLL;
using Melidya2.Entity;
using Melidya2.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Melidya2.UI.Controllers
{
    public class OrderController : Controller
    {
        OrderBLL orderBLL = new OrderBLL();
        ProductBLL productBLL = new ProductBLL();
        OrderDetailBLL orderdetailBLL = new OrderDetailBLL();

        public ActionResult Index()
        {
            Customers customer = (Customers)Session["Login"];
            List<Orders> orders = orderBLL.GetOrders(customer.CustomerID);

            return View(orders);
        }
        public ActionResult OrderDetail(int id)
        {
            List<Order_Details> order_Details = orderdetailBLL.GetOrder_Details(id);

            return View(order_Details);
        }

        public ActionResult AddOrder()
        {
            Customers customer = Session["Login"] as Customers;
            int orderID = orderBLL.AddOrder(customer);
            List<SepetModel> model = Session["Sepet"] as List<SepetModel>;
            foreach (SepetModel item in model)
            {
                Products product = productBLL.GetProduct(item.ProductID);
                orderdetailBLL.AddOrderDetail(product, item.Quantity, orderID);
            }
            return RedirectToAction("Index");
        }
    }
}