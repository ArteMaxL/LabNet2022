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
    public class CategoryController : ApiController
    {
        CategoryLogic categoryLogic = new CategoryLogic();

        // GET: api/Category
        public IHttpActionResult Get()
        {
            try
            {
                IQueryable<CategoryView> categoryView = categoryLogic
                    .GetAll()
                    .Select(c => new CategoryView
                {
                    CategoryID = c.CategoryID,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                });

                return Ok(categoryView);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // GET: api/Category
        public IHttpActionResult Get(int id)
        {
            try
            {
                Categories categoryEntity = categoryLogic.GetOne(id);

                if (categoryEntity != null)
                {
                    CategoryView categoryView = new CategoryView
                    {
                        CategoryID = categoryEntity.CategoryID,
                        CategoryName = categoryEntity.CategoryName,
                        Description = categoryEntity.Description,
                    };

                    return Ok(categoryView);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound,
                        $"The category with the ID: '{id}' doesn't exist!.");
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // POST: api/category 
        public IHttpActionResult Post([FromBody] CategoryView categoryView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Categories categoryEntity = new Categories
                    {
                        CategoryName = categoryView.CategoryName,
                        Description = categoryView.Description,
                    };

                    categoryLogic.Add(categoryEntity);
                                        
                    return Content(HttpStatusCode.Created, categoryEntity);
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

        // PUT: api/category
        public IHttpActionResult Put([FromBody] CategoryView categoryView)
        {
            if (ModelState.IsValid)
            {
                if (categoryLogic.GetOne(categoryView.CategoryID) != null)
                {
                    try
                    {
                        Categories categoryEntity = new Categories
                        {
                            CategoryID = categoryView.CategoryID,
                            CategoryName = categoryView.CategoryName,
                            Description = categoryView.Description,
                        };

                        categoryLogic.Update(categoryEntity);
                        return Ok(categoryEntity);
                    }
                    catch (Exception ex)
                    {
                        return Content(HttpStatusCode.InternalServerError, ex.Message);
                    }
                }
                else
                {
                    return Content(HttpStatusCode.NotFound,
                            $"The category with the ID: '{categoryView.CategoryID}' doesn't exist!.");
                }
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Fields are missing or too long!.");
            }
        }

        // DELETE: api/category
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (categoryLogic.GetOne(id) != null)
                {
                    categoryLogic.Delete(id);
                    return Content(HttpStatusCode.Accepted, $"Category with the ID: {id} was deleted!.");
                }
                else
                {
                    return Content(HttpStatusCode.NotFound,
                            $"The category with the ID: '{id}' doesn't exist!.");
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.Forbidden, ex.Message);
            }
        }
    }
}