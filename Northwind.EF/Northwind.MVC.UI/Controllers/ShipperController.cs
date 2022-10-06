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
    public class ShipperController : Controller
    {
        ShipperLogic shipperLogic = new ShipperLogic();
        // GET: Shipper
        public ActionResult Index()
        {
            IQueryable<Shippers> shippers = shipperLogic.GetAll();

            IQueryable<ShipperView> shipperViews = shippers.Select(s => new ShipperView
            {
                Id = s.ShipperID,
                Name = s.CompanyName,
                Phone = s.Phone,
            });

            return View(shipperViews);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(ShipperView shipperView)
        {
            Shippers shipperEntity = new Shippers
            {
                ShipperID = shipperView.Id,
                CompanyName = shipperView.Name,
                Phone = shipperView.Phone,
            };

            if (!ModelState.IsValid)
            {
                return View(shipperView);
            }

            if (shipperEntity.ShipperID == 0)
            {
                shipperLogic.Add(shipperEntity);
            }
            else
            {
                try
                {
                    shipperLogic.Update(shipperEntity);
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    return RedirectToAction("Index", "Error");
                    throw new DbUnexpectedValidationException("An error has occurred!.");
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            try
            {
                shipperLogic.Delete(id);
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