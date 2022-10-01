using Northwind.Linq.Common;
using Northwind.Linq.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Linq.Logic
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

        public void DeleteByString(string id)
        {
            var customer = _context.Customers.Single(c => c.CustomerID == id);
            _context.Customers.Remove(customer);

            _context.SaveChanges();
        }

        // Ejercicio 6 ??
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

        public Customers GetOneString(string id)
        {
            var customer = _context.Customers.Where(c => c.CustomerID == id)
                                             .SingleOrDefault();
                return customer;
        }

        public IQueryable<Customers> GetCustomersRegionWA()
        {
            var customers = _context.Customers.Where(c => c.Region == "WA");
                                              //.ToList();
            return customers;
        }

        public IQueryable<CustomersOrders> CustomersJoinOrdersRegionWADate1997()
        {
            DateTime date = new DateTime(1997, 01, 01);

            var customersOrders = from Customers in _context.Customers
                                  join Orders in _context.Orders
                                  on Customers.CustomerID equals Orders.CustomerID
                                  where Orders.OrderDate > date && Customers.Region == "WA"
                                  select new CustomersOrders
                                  {
                                      CustomerID = Customers.CustomerID,
                                      CompanyName = Customers.CompanyName,
                                      OrderID = Orders.OrderID,
                                  };

            return customersOrders;
        }

        public List<Customers> GetFirst3CustomersRegionWA()
        {
            var customers = _context.Customers.Where(c => c.Region == "WA")
                                              .Take(3)
                                              .ToList();
            return customers;
        }

        public IQueryable<CustomersOrders> CustomersWithQuantityAssociatedOrders()
        {
            var customerOrders = from customers in _context.Customers
                                 join orders in _context.Orders
                                 on customers.CustomerID equals orders.CustomerID
                                 group customers by new
                                 {
                                     customers.CustomerID,
                                     customers.CompanyName,
                                 }
                                 into tempTable

                                 select new CustomersOrders
                                 {
                                     CustomerID = tempTable.Key.CustomerID,
                                     CompanyName = tempTable.Key.CompanyName,
                                     QuantityOrders = tempTable.Count(),
                                 };

            return customerOrders;
        }
    }
}
