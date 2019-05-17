using Melidya2.DAL;
using Melidya2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melidya2.BLL
{
    public class OrderDetailBLL
    {
        Repository<Order_Details> repo = new Repository<Order_Details>();
        DataContext db = new DataContext();

        public List<Order_Details> GetOrder_Details(int id)
        {
            return repo.List(x=>x.OrderID == id);
        }

        public void AddOrderDetail(Products product, int quantity, int orderID)
        {
            Order_Details orderdetail = new Order_Details();
            orderdetail.OrderID = orderID;
            orderdetail.ProductID = product.ProductID;
            orderdetail.UnitPrice = (decimal)product.UnitPrice;
            orderdetail.Quantity = Convert.ToInt16(quantity);
            orderdetail.Discount = 0;
            db.Order_Details.Add(orderdetail);
            db.SaveChanges();
        }
    }
}
