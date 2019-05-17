using Melidya2.DAL;
using Melidya2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melidya2.BLL
{
    public class CustomerBLL
    {
        Repository<Customers> repo = new Repository<Customers>();

        public Customers GetCustomer(string id)
        {
            return repo.Find(x => x.CustomerID == id);
        }

        public void Update(Customers customers)
        {
            repo.Update(customers);
        }
    }
}
