﻿using Northwind.Linq.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Linq.Logic
{
    public class ProductLogic : BaseLogic<Products>
    {

        // Metodos Heredados 
        public override void Add(Products newT)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Products> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Products GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Products updateT)
        {
            throw new NotImplementedException();
        }

        // Metodos Especificos TP 5

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

        public Products GetProductWithId789()
        {
            var product = _context.Products.Where(p => p.ProductID == 789)
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

        public Products GetFirstElementOfList(List<Products> productlist)
        {
            var product = productlist.First();
            return product;
        } 
    }
}
