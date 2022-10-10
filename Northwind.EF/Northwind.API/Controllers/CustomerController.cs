using Northwind.API.Models;
using Northwind.EF.Entities;
using Northwind.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace Northwind.API.Controllers
{
    public class CustomerController : ApiController
    {
        CustomerLogic customerLogic = new CustomerLogic();

        // GET: api/customer
        public IHttpActionResult Get()
        {
            try
            {
                IQueryable<CustomerView> customerView = customerLogic
                    .GetAll()
                    .Select(c => new CustomerView
                    {
                        CustomerID = c.CustomerID,
                        CompanyName = c.CompanyName,
                        ContactName = c.ContactName,
                        ContactTitle = c.ContactTitle,
                        City = c.City,
                        Phone = c.Phone,
                    });

                return Ok(customerView);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // GET: api/customer
        public IHttpActionResult Get(string id)
        {
            try
            {
                Customers customerEntity = customerLogic.GetOneString(id);

                if (customerEntity != null)
                {
                    CustomerView customerView = new CustomerView
                    {
                        CustomerID = customerEntity.CustomerID,
                        CompanyName = customerEntity.CompanyName,
                        ContactName = customerEntity.ContactName,
                        ContactTitle = customerEntity.ContactTitle,
                        City = customerEntity.City,
                        Phone = customerEntity.Phone,
                    };

                    return Ok(customerView);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound,
                        $"The customer with the ID: '{id}' doesn't exist!.");
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // POST: api/customer 
        public IHttpActionResult Post([FromBody] CustomerView customerView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Customers customerEntity = new Customers
                    {
                        CompanyName = customerView.CompanyName,
                        ContactName = customerView.ContactName,
                        ContactTitle = customerView.ContactTitle,
                        City = customerView.City,
                        Phone = customerView.Phone,
                    };

                    customerLogic.Add(customerEntity);

                    return Content(HttpStatusCode.Created, customerEntity);
                }
                catch (Exception ex)
                {
                    return Content(HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Fields are missing or too long!.");
            }
        }

        // PUT: api/customer
        public IHttpActionResult Put([FromBody] CustomerView customerView)
        {
            if (ModelState.IsValid)
            {
                if (customerLogic.GetOneString(customerView.CustomerID) != null)
                {
                    try
                    {
                        Customers customerEntity = new Customers
                        {
                            CustomerID = customerView.CustomerID,
                            CompanyName = customerView.CompanyName,
                            ContactName = customerView.ContactName,
                            ContactTitle = customerView.ContactTitle,
                            City = customerView.City,
                            Phone = customerView.Phone,
                        };

                        customerLogic.Update(customerEntity);
                        return Ok(customerEntity);
                    }
                    catch (Exception ex)
                    {
                        return Content(HttpStatusCode.InternalServerError, ex.Message);
                    }
                }
                else
                {
                    return Content(HttpStatusCode.NotFound,
                            $"The customer with the ID: '{customerView.CustomerID}' doesn't exist!.");
                }
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Fields are missing or too long!.");
            }
        }

        // DELETE: api/customer       
        public IHttpActionResult Delete(string id)
        {
            try
            {
                if (customerLogic.GetOneString(id) != null)
                {
                    customerLogic.DeleteByString(id);
                    return Content(HttpStatusCode.Accepted, $"Customer with the ID: {id} was deleted!.");
                }
                else
                {
                    return Content(HttpStatusCode.NotFound,
                            $"The customer with the ID: '{id}' doesn't exist!.");
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.Forbidden, ex.Message);
            }
        }
    }
}