using Northwind.Linq.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Linq.Logic
{
    public class ProductLogic : BaseLogic<Products>
    {
        public override void Add(Products product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);

            _context.SaveChanges();
        }

        public override IQueryable<Products> GetAll()
        {
            return _context.Products;
        }

        public override Products GetOne(int id)
        {
            return _context.Products.Find(id);
        }

        public override void Update(Products productNew)
        {
            var productUpdate = _context.Products.Find(productNew.ProductID);

            productUpdate.ProductName = productNew.ProductName;
            productUpdate.UnitsInStock = productNew.UnitsInStock;
            productUpdate.UnitPrice = productNew.UnitPrice;

            _context.SaveChanges();
        }

        public IQueryable<Products> GetProductsWhitoutStock()
        {
            var products = _context.Products.Where(p => p.UnitsInStock == 0);
            return products;
        }

        public IQueryable<Products> GetProductsWhithStockPriceUpTo3()
        {
            var products = _context.Products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);                                            
            return products;
        }

        public Products GetProductWithId789(IQueryable<Products> products)
        {
            var product = products.Where(p => p.ProductID == 789)
                                           .FirstOrDefault();
            return product;
        }

        public List<Products> GetProductsOrderByName()
        {
            var products = _context.Products.OrderBy(p => p.ProductName)
                                            .ToList();
            return products;
        }
        
        public List<Products> GetProductsOrderByUnitStockMajorToMinor()
        {
            var products = from product in _context.Products
                           orderby product.UnitsInStock descending
                           select product;

            return products.ToList();
        }

        public Products GetFirstElementOfList(IQueryable<Products> productlist)
        {
            var product = productlist.First();
            return product;
        }

        public IQueryable<ProductCategories> ProductByCategories()
        {
            var products = from Categories in _context.Categories
                           join Products in _context.Products
                           on Categories.CategoryID equals Products.CategoryID
                           select new ProductCategories
                           {
                               ProductID = Products.ProductID,
                               ProductName = Products.ProductName,
                               CategoryID = Categories.CategoryID,
                               CategoryName = Categories.CategoryName
                           };
            return products;
        }
    }
}
