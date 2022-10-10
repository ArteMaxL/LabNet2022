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
    public class ShipperController : ApiController
    {
        ShipperLogic shipperLogic = new ShipperLogic();

        // GET: api/shipper
        public IHttpActionResult Get()
        {
            try
            {
                IQueryable<ShipperView> shipperView = shipperLogic
                    .GetAll()
                    .Select(s => new ShipperView
                    {
                        ShipperID = s.ShipperID,
                        CompanyName = s.CompanyName,
                        Phone = s.Phone,
                    });

                return Ok(shipperView);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // GET: api/shipper
        public IHttpActionResult Get(int id)
        {
            try
            {
                Shippers shipperEntity = shipperLogic.GetOne(id);

                if (shipperEntity != null)
                {
                    ShipperView shipperView = new ShipperView
                    {
                        ShipperID = shipperEntity.ShipperID,
                        CompanyName = shipperEntity.CompanyName,
                        Phone = shipperEntity.Phone,
                    };

                    return Ok(shipperView);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound,
                        $"The shipper with the ID: '{id}' doesn't exist!.");
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // POST: api/shipper 
        public IHttpActionResult Post([FromBody] ShipperView shipperView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Shippers shipperEntity = new Shippers
                    {
                        CompanyName = shipperView.CompanyName,
                        Phone = shipperView.Phone,
                    };

                    shipperLogic.Add(shipperEntity);

                    return Content(HttpStatusCode.Created, shipperEntity);
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

        // PUT: api/shipper
        public IHttpActionResult Put([FromBody] ShipperView shipperView)
        {
            if (ModelState.IsValid)
            {
                if (shipperLogic.GetOne(shipperView.ShipperID) != null)
                {
                    try
                    {
                        Shippers shipperEntity = new Shippers
                        {
                            ShipperID = shipperView.ShipperID,
                            CompanyName = shipperView.CompanyName,
                            Phone = shipperView.Phone,
                        };

                        shipperLogic.Update(shipperEntity);
                        return Ok(shipperEntity);
                    }
                    catch (Exception ex)
                    {
                        return Content(HttpStatusCode.InternalServerError, ex.Message);
                    }
                }
                else
                {
                    return Content(HttpStatusCode.NotFound,
                            $"The category with the ID: '{shipperView.ShipperID}' doesn't exist!.");
                }
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Fields are missing or too long!.");
            }
        }

        // DELETE: api/shipper
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (shipperLogic.GetOne(id) != null)
                {
                    shipperLogic.Delete(id);
                    return Content(HttpStatusCode.Accepted, $"Shipper with the ID: {id} was deleted!.");
                }
                else
                {
                    return Content(HttpStatusCode.NotFound,
                            $"The shipper with the ID: '{id}' doesn't exist!.");
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}