using Northwind.EF.Common;
using Northwind.EF.Entities;
using Northwind.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.EF.UI
{
    public class CustomerUI : UIBase
    {

        public override void List()
        {
            CustomerLogic customerLogic = new CustomerLogic();
            var customers = customerLogic.GetAll();

            foreach (Customers customer in customers)
            {
                Console.WriteLine($"ID: {customer.CustomerID}\tCategory Name: {customer.CompanyName}");
                Console.WriteLine($"Customer Contact Name: {customer.ContactName}");
                Console.WriteLine("-------------------------------------------------");
            }
            Console.WriteLine($"{System.Environment.NewLine}===Press any key to continue===");
            Console.ReadKey();
        }

        public override void Add()
        {
            CustomerLogic customerLogic = new CustomerLogic();
            var valid = new Validation();
            var customers = customerLogic.GetAll();
            string quantity = null;
            string input = null;
            string companyName = null;
            string contactName = null;

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nEnter a Customer Company Name (max 40 characters):\n");
                input = Console.ReadLine();
                if (valid.CategoryLong(input, 40))
                {
                    companyName = input;
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Name too long!.");
                    Thread.Sleep(1500);
                }
                Console.Clear();
            }

            exit = false;
            while (!exit)
            {
                Console.WriteLine("\nEnter a Customer Contact Name (max 30 characters):\n");
                input = Console.ReadLine();
                if (valid.CategoryLong(input, 30))
                {
                    contactName = input;
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Name too long!.");
                    Thread.Sleep(1500);
                }
                Console.Clear();
            }

            try
            {
                quantity = companyName.Substring(0, 5).ToUpper();
                customerLogic.Add(new Customers
                {
                    CustomerID = quantity,
                    CompanyName = companyName,
                    ContactName = contactName,
                });

                Console.WriteLine("Company added!\n");
                Console.WriteLine("Press any key to continue...");
                Console.WriteLine("\n======================\n");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                var message = CustomExceptions.CustomException(e);
                foreach (var item in message)
                {
                    Console.WriteLine($"{item}\n");
                }
            }
            Console.Clear();
            List();
        }

        public override void Delete() //TODO
        {
            CategoryLogic categoryLogic = new CategoryLogic();
            var valid = new Validation();
            string input = null;

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nEnter a number ID:\n");
                input = Console.ReadLine();
                if (valid.IsValid(input))
                {
                    exit = valid.IsValid(input);
                }
                Console.Clear();
            }
            var id = Int32.Parse(input);
            var categoryDelete = categoryLogic.GetOne(id);

            if (categoryDelete != null)
            {
                try
                {
                    categoryLogic.Delete(categoryDelete.CategoryID);
                    Console.WriteLine("Category to be deleted:\n");
                    Console.WriteLine($"ID: {categoryDelete.CategoryID}\tCategory Name: {categoryDelete.CategoryName}");
                    Console.WriteLine($"Category Description: {categoryDelete.Description}");
                    Console.WriteLine("Press any key to continue...");
                    Console.WriteLine("\n======================\n");
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    var message = CustomExceptions.CustomException(e);
                    foreach (var item in message)
                    {
                        Console.WriteLine($"{item}\n");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Category with ID: {id} not found!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            Console.Clear();
            List();
        }

        public override void Update()
        {
            CategoryLogic categoryLogic = new CategoryLogic();
            var valid = new Validation();
            string input = null;
            string inputName = null;
            string description = null;

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nEnter a number ID:\n");
                input = Console.ReadLine();
                if (valid.IsValid(input))
                {
                    exit = valid.IsValid(input);
                }
                Console.Clear();
            }
            var id = Int32.Parse(input);
            var categoryUpdate = categoryLogic.GetOne(id);

            if (categoryUpdate != null)
            {
                exit = false;
                while (!exit)
                {
                    Console.WriteLine("\nEnter a Category Name (max 15 characters):\n");
                    input = Console.ReadLine();
                    if (valid.CategoryLong(input))
                    {
                        inputName = input;
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("Name too long!.");
                        Thread.Sleep(1500);
                    }
                    Console.Clear();
                }
                Console.WriteLine("\nEnter a Category Description:\n");
                description = Console.ReadLine();
                try
                {
                    categoryLogic.Update(new Categories
                    {
                        CategoryID = categoryUpdate.CategoryID,
                        CategoryName = inputName,
                        Description = description,
                    });
                }
                catch (Exception e)
                {
                    var message = CustomExceptions.CustomException(e);
                    foreach (var item in message)
                    {
                        Console.WriteLine($"{item}\n");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Category with ID: {id} not found!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            Console.Clear();
            List();
        }
    }
}
