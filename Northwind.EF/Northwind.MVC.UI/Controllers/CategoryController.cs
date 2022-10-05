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
    public class CategoryController : Controller
    {
        CategoryLogic categoryLogic = new CategoryLogic();

        [HttpGet]
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

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CategoryView categoryView)
        {
            Categories categoryEntity = new Categories
                {
                    CategoryName = categoryView.Name,
                    Description = categoryView.Description,
                };

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("error", "Invalid model");
                return RedirectToAction("Index");
            }

            if (categoryEntity.CategoryID == 0)
            {
                categoryLogic.Add(categoryEntity);
            }
            else
            {
                try
                {
                    categoryLogic.Update(categoryEntity);
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                {
                    ModelState.AddModelError("error", e.Message);
                    return RedirectToAction("Index", "Error");
                }
            }
            return RedirectToAction("Index");
        }

        //[HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                categoryLogic.Delete(id);
                return RedirectToAction("Index");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}