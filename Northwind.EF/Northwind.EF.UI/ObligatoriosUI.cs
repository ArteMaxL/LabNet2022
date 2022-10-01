using Northwind.Linq.UI;
using Northwind.Linq.Common;
using Northwind.Linq.Logic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Northwind.Linq.Entities;

namespace Northwind.Linq.UI
{
    public class ObligatoriosUI : BaseUI
    {
        public void Ejercicio1()
        {
            var valid = new Validation();
            string id = "";

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n\t1 - Objeto customer.\n");
                Console.WriteLine("\nIngresa el CustomerID (5 caracteres obligatorio):\n");
                Console.WriteLine("Si quieres puedes probar con 'WOLZA'\n");
                var input = Console.ReadLine();
                if (valid.ValidCharId(input))
                {
                    id = input.ToUpper();
                    exit = true;
                }
                else
                {
                    Console.WriteLine("CompanyID incorrecto, 5 caracteres obligatorio!.");
                    Thread.Sleep(1500);
                }
                Console.Clear();
            }

            var customer = _customerLogic.GetOneString(id);

            if (customer != null)
            {
                Console.WriteLine($"Company ID: {customer.CustomerID}");
                Console.WriteLine($"Company Name: {customer.CompanyName}");
                Console.WriteLine($"Contact Name: {customer.ContactName}");
                Console.WriteLine($"Contact Phone: {customer.Phone}");
                Console.WriteLine("\nPresione cualquier tecla para continuar...\n");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"No existe una compania con CompanyID '{id}'");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        public void Ejercicio2()
        {
            Console.WriteLine("\n\t2 - Todos los productos sin stock.\n");

            var products = _productLogic.GetProductsWhitoutStock().ToList();

            if (products != null)
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"Product ID: {product.ProductID}");
                    Console.WriteLine($"Product Name: {product.ProductName}");
                    Console.WriteLine($"Unit Price: {product.UnitPrice}");
                    Console.WriteLine($"Units in Stock: {product.UnitsInStock}");
                    Console.WriteLine("------------------------------------------------");
                }
                Console.WriteLine("\nPresione cualquier tecla para continuar...\n");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"No existen Productos sin stock.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        public void Ejercicio3()
        {
            Console.WriteLine("\n\t3 - Todos los productos que tienen stock y que cuestan más de 3 por unidad.\n");

            var products = _productLogic.GetProductsWhithStockPriceUpTo3().ToList();

            if (products != null)
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"Product ID: {product.ProductID}");
                    Console.WriteLine($"Product Name: {product.ProductName}");
                    Console.WriteLine($"Unit Price: {product.UnitPrice}");
                    Console.WriteLine($"Units in Stock: {product.UnitsInStock}");
                    Console.WriteLine("------------------------------------------------");
                }
                Console.WriteLine("\nPresione cualquier tecla para continuar...\n");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"No existen Productos sin stock.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        public void Ejercicio4()
        {
            Console.WriteLine("\n\t4 - Todos los customers de la Región WA.\n");

            var customers = _customerLogic.GetCustomersRegionWA().ToList();

            if (customers != null)
            {
                foreach (var customer in customers)
                {
                    Console.WriteLine($"Customer ID: {customer.CustomerID}");
                    Console.WriteLine($"Company Name: {customer.CompanyName}");
                    Console.WriteLine($"Contact Name: {customer.ContactName}");
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
    }
}
