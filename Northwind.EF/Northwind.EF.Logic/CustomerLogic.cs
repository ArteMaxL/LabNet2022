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
            try
            {
                var valid = new Validation();
                var stringId = valid.GenerateStringID();
                customer.CustomerID = stringId;

                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                var customer = _context.Customers.Find(id);
                _context.Customers.Remove(customer);

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteByString(string id)
        {
            try
            {
                var customer = _context.Customers.Single(c => c.CustomerID == id);
                _context.Customers.Remove(customer);

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override IQueryable<Customers> GetAll()
        {
            try
            {
                return _context.Customers;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override Customers GetOne(int id)
        {
            try
            {
                return _context.Customers.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Customers GetOneString(string id)
        {
            try
            {
                var customer = _context.Customers.Single(c => c.CustomerID == id);
                return customer;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override void Update(Customers customerNew)
        {
            try
            {
                var customerUpdate = _context.Customers.Find(customerNew.CustomerID);

                customerUpdate.CompanyName = customerNew.CompanyName;
                customerUpdate.ContactName = customerNew.ContactName;
                customerUpdate.ContactTitle = customerNew.ContactTitle;
                customerUpdate.City = customerNew.City;
                customerUpdate.Phone = customerNew.Phone;

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
