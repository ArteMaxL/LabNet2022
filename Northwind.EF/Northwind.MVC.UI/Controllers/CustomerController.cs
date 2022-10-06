using Northwind.EF.Entities;
using Northwind.EF.Logic;
using Northwind.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MVC.UI.Controllers
{
    public class CustomerController : Controller
    {
        CustomerLogic customerLogic = new CustomerLogic();
        // GET: Customer
        public ActionResult Index()
        {
            IQueryable<Customers> customers = customerLogic.GetAll();

            IQueryable<CustomerView> customerViews = customers.Select(c => new CustomerView
            {
                Id = c.CustomerID,
                CompanyName = c.CompanyName,
                ContactName = c.ContactName,
                ContactTitle = c.ContactTitle,
                City = c.City,
                Phone = c.Phone,
            });

            return View(customerViews);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CustomerView customerView)
        {
            Customers customerEntity = new Customers
            {
                CustomerID = customerView.Id,
                CompanyName = customerView.CompanyName,
                ContactName= customerView.ContactName,
                ContactTitle= customerView.ContactTitle,
                City= customerView.City,
                Phone= customerView.Phone,
            };

            if (!ModelState.IsValid)
            {
                return View(customerView);
            }

            if (customerEntity.CustomerID == null)
            {
                customerLogic.Add(customerEntity);
            }
            else
            {
                try
                {
                    customerLogic.Update(customerEntity);
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    return RedirectToAction("Index", "Error");
                    throw new DbUnexpectedValidationException("An error has occurred!.");
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            try
            {
                customerLogic.DeleteByString(id);
                return RedirectToAction("Index");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                ModelState.AddModelError("", "Cannot delete because this table is related to another table. Try deleting a new record...");
                return RedirectToAction("Index", "Error");
                throw new DbUnexpectedValidationException("An error has occurred!.");
            }
        }
    }
}