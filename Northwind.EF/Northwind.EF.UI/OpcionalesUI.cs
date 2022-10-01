using Northwind.Linq.Entities;
using Northwind.Linq.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.EF.UI
{
    public class OpcionalesUI : BaseUI
    {
        public void Ejercicio1()
        {
            Console.WriteLine("\n\t1 - Primeros 3 Customers de la Región WA.\n");

            var customers = _customerLogic.GetFirst3CustomersRegionWA();

            if (customers != null)
            {
                foreach (var customer in customers)
                {
                    Console.WriteLine($"Customer ID: {customer.CustomerID}");
                    Console.WriteLine($"Company Name: {customer.CompanyName}");
                    Console.WriteLine($"Company Region: {customer.Region}");
                    Console.WriteLine("------------------------------------------------");
                }
                Console.WriteLine("\nPresione cualquier tecla para continuar...\n");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"No existen Customers en la Region WA.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        public void Ejercicio2()
        {
            Console.WriteLine("\n\t2 - Lista de productos ordenados por nombre.\n");

            var products = _productLogic.GetProductsOrderByName();

            if (products != null)
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"Product ID: {product.ProductID}");
                    Console.WriteLine($"Product Name: {product.ProductName}");
                    Console.WriteLine("------------------------------------------------");
                }
                Console.WriteLine("\nPresione cualquier tecla para continuar...\n");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"No existen Productos.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        public void Ejercicio3()
        {
            Console.WriteLine("\n\t3 - Lista de productos ordenados por unit in stock de mayor a menor.\n");

            var products = _productLogic.GetProductsOrderByUnitStockMajorToMinor();

            if (products != null)
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"Product ID: {product.ProductID}");
                    Console.WriteLine($"Product Name: {product.ProductName}");
                    Console.WriteLine($"Units in Stock: {product.UnitsInStock}");
                    Console.WriteLine("------------------------------------------------");
                }
                Console.WriteLine("\nPresione cualquier tecla para continuar...\n");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"No existen Productos.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        public void Ejercicio4()
        {
            Console.WriteLine("\n\t4 - Categorías asociadas a los productos.\n");

            var products = _productLogic.ProductByCategories();

            if (products != null)
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"Product ID: {product.ProductID}");
                    Console.WriteLine($"Product Name: {product.ProductName}");
                    Console.WriteLine("\n\tCategoria Asociada:\n");
                    Console.WriteLine($"Category ID: {product.CategoryID}");
                    Console.WriteLine($"Category Name: {product.CategoryName}");
                    Console.WriteLine("------------------------------------------------");
                }
                Console.WriteLine("\nPresione cualquier tecla para continuar...\n");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"No existen Categorias asociadas a Products.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        public void Ejercicio5()
        {
            Console.WriteLine("\n\t5 - Primer elemento de una lista de productos.\n");

            var product = _productLogic.GetFirstElementOfList(_productLogic.GetAll());

            if (product != null)
            {                
                Console.WriteLine($"Product ID: {product.ProductID}");
                Console.WriteLine($"Product Name: {product.ProductName}");
                Console.WriteLine($"Unit Price: {product.UnitPrice}");
                Console.WriteLine($"Units in Stock: {product.UnitsInStock}");
                
                Console.WriteLine("\nPresione cualquier tecla para continuar...\n");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"No existe el Producto.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        public void Ejercicio6()
        {
            Console.WriteLine("\n\t6 - Devolver los Customer con la cantidad de ordenes asociadas.\n");

            var customers = _customerLogic.CustomersWithQuantityAssociatedOrders();

            if (customers != null)
            {
                foreach (var customer in customers)
                {
                    Console.WriteLine($"Company ID: {customer.CustomerID}");
                    Console.WriteLine($"Company Name: {customer.CompanyName}");
                    Console.WriteLine($"Quantity Orders: {customer.QuantityOrders}");
                    Console.WriteLine("------------------------------------------------");
                }
                Console.WriteLine("\nPresione cualquier tecla para continuar...\n");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"No existen Customer con ordenes asociadas");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
