using Northwind.API.Models;
using Northwind.EF.Entities;
using Northwind.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Northwind.API.Controllers
{
    public class FakeStoreController : Controller
    {
        FakeStoreLogic fakeStoreLogic = new FakeStoreLogic();

        // GET: FakeStore
        public async Task<ActionResult> Index()
        {
            IQueryable<FakeStoreAPI> products = await fakeStoreLogic.GetProducts();

            IQueryable<FakeStoreView> productView = products.Select(p => new FakeStoreView
            {
                Id = p.Id,
                Title = p.Title,
                Price = p.Price,
                Category = p.Category,
                Description = p.Description,
                Image = p.Image,
            });

            return View(productView);
        }
    }
}