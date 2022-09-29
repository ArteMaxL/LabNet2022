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
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var category = _context.Categories.Find(id);           
            _context.Categories.Remove(category);

            _context.SaveChanges();
        }

        public override List<Categories> GetAll()
        {
            return _context.Categories.ToList();
        }

        public override Categories GetOne(int id)
        {
            return _context.Categories.Find(id);
        }

        public int GetNextId()
        {
            var category = _context.Categories.Max(c => c.CategoryID);
            return category;
        }

        public override void Update(Categories categoryNew)
        {
            var categoryUpdate = _context.Categories.Find(categoryNew.CategoryID);

            categoryUpdate.CategoryName = categoryNew.CategoryName;
            categoryUpdate.Description = categoryNew.Description;

            _context.SaveChanges();
        }
    }
}
