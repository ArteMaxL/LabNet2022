using Northwind.EF.Common;
using Northwind.EF.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.EF.Logic
{
    public class CustomerLogic : BaseLogic<Customers>
    {
        public override void Add(Customers customer)
        {
            var valid = new Validation();
            var stringId = valid.GenerateStringID();
            customer.CustomerID = stringId;

            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);

            _context.SaveChanges();
        }

        public void DeleteByString(string id)
        {
            var customer = _context.Customers.Single(c => c.CustomerID == id);
            _context.Customers.Remove(customer);

            _context.SaveChanges();
        }

        public override IQueryable<Customers> GetAll()
        {
            return _context.Customers;
        }

        public override Customers GetOne(int id)
        {
            return _context.Customers.Find(id);
        }

        public Customers GetOneString(string id)
        {
            var customer = _context.Customers.Single(c => c.CustomerID == id);
            return customer;
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
