using Northwind.EF.Entities;
using Northwind.EF.Logic;
using Northwind.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MVC.UI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryLogic categoryLogic = new CategoryLogic();
        // GET: Category
        public ActionResult Index()
        {
            IQueryable<Categories> categories = categoryLogic.GetAll();

            IQueryable<CategoryView> categoryViews = categories.Select(c => new CategoryView
            {
                Id = c.CategoryID,
                Name = c.CategoryName,
                Description = c.Description,
            });

            return View(categoryViews);
        }

        public ActionResult Insert()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Insert(CategoryView categoryView)
        {
            try
            {
                Categories categoryEntity = new Categories
                {
                    CategoryName = categoryView.Name,
                    Description = categoryView.Description,
                };

                categoryLogic.Add(categoryEntity);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}