using Melidya2.DAL;
using Melidya2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melidya2.BLL
{
    public class OrderBLL
    {
        Repository<Orders> repo = new Repository<Orders>();
        DataContext db = new DataContext();

        public List<Orders> GetOrders(string id)
        {
            return repo.List(x=>x.CustomerID == id);
        }

        public Orders GetOrder(int OrderId)
        {
            return repo.Find(x => x.OrderID == OrderId);
        }

        public int AddOrder(Customers Customer)
        {
            Orders order = new Orders();
            order.CustomerID = Customer.CustomerID;
            order.EmployeeID = 3;
            order.OrderDate = DateTime.Now;
            order.Freight = (decimal)6.90;
            db.Orders.Add(order);
            db.SaveChanges();
            return order.OrderID;
        }

    }
}
