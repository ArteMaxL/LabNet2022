using Northwind.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.EF.Logic
{
    public class CustomerLogic : BaseLogic<Customers>
    {
        public override void Add(Customers customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);

            _context.SaveChanges();
        }

        public override List<Customers> GetAll()
        {
            return _context.Customers.ToList();
        }

        public override Customers GetOne(int id)
        {
            return _context.Customers.Find(id);
        }

        public override void Update(Customers customerNew)
        {
            var customerUpdate = _context.Customers.Find(customerNew.CustomerID);

            customerUpdate.CompanyName = customerNew.CompanyName;
            customerUpdate.ContactName = customerNew.ContactName;            

            _context.SaveChanges();
        }
    }
}
