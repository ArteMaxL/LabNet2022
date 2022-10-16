using Northwind.API.Models;
using Northwind.EF.Entities;
using Northwind.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Northwind.API.Controllers
{
    public class FakeStoreAPIController : ApiController
    {
        FakeStoreLogic fakeStoreLogic = new FakeStoreLogic();

        // GET: FakeStoreAPI
        public async Task<IHttpActionResult> Get()
        {
            List<FakeStoreAPI> products = await fakeStoreLogic.GetProducts();

            List<FakeStoreView> productView = products.Select(p => new FakeStoreView
            {
                Id = p.Id,
                Title = p.Title,
                Price = p.Price,
                Category = p.Category,
                Description = p.Description,
                Image = p.Image,
            }).ToList();

            return Ok(productView);
        }
    }
}