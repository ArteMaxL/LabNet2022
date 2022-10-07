using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.EF.Data;
using Northwind.EF.Entities;

namespace Northwind.EF.Logic
{
    public class CategoryLogic : BaseLogic<Categories>
    {
        public override void Add(Categories category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public override void Delete(int id)
        {
            try
            {
                var category = _context.Categories.Find(id);           
                _context.Categories.Remove(category);

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override IQueryable<Categories> GetAll()
        {
            try
            {
                return _context.Categories;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public override Categories GetOne(int id)
        {
            try
            {
                return _context.Categories.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int GetNextId()
        {
            try
            {
                var category = _context.Categories.Max(c => c.CategoryID);
                return category;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override void Update(Categories categoryNew)
        {
            try
            {
                var categoryUpdate = _context.Categories.Find(categoryNew.CategoryID);

                categoryUpdate.CategoryName = categoryNew.CategoryName;
                categoryUpdate.Description = categoryNew.Description;

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
