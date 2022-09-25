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
                Console.WriteLine($"ID: {customer.CustomerID}\tCustomer Company Name: {customer.CompanyName}");
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
            string ID = valid.GenerateStringID();
            string input = null;
            string companyName = null;
            string contactName = null;

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nEnter a Customer Company Name (max 40 characters):\n");
                input = Console.ReadLine();
                if (valid.NameLong(input, 40))
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
                if (valid.NameLong(input, 30))
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
                customerLogic.Add(new Customers
                {
                    CustomerID = ID,
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
                Console.Clear();
                var message = CustomExceptions.CustomException(e);
                foreach (var item in message)
                {
                    Console.WriteLine($"{item}\n");
                }                
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            Console.Clear();
            List();
        }

        public override void Delete()
        {
            CustomerLogic customerLogic = new CustomerLogic();
            var valid = new Validation();
            string input = null;

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nEnter a number ID:\n");
                input = Console.ReadLine();
                if (valid.IsValidString(input))
                {
                    exit = valid.IsValidString(input);
                }
                Console.Clear();
            }
            var id = input;
            try
            {
                var customerDelete = customerLogic.GetOneString(id);

                if (customerDelete != null)
                {
                    customerLogic.DeleteByString(customerDelete.CustomerID);
                    Console.WriteLine("Customer to be deleted:\n");
                    Console.WriteLine($"ID: {customerDelete.CustomerID}\tCompany Name: {customerDelete.CompanyName}");
                    Console.WriteLine($"Company Contact Name: {customerDelete.ContactName}");
                    Console.WriteLine("Press any key to continue...");
                    Console.WriteLine("\n======================\n");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"Company with ID: {id} not found!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            catch (InvalidOperationException e)
            {
                Console.Clear();
                var message = CustomExceptions.CustomInvalidOperationException(e);
                foreach (var item in message)
                {                    
                    Console.WriteLine($"{item}\n");                    
                }
                Console.WriteLine($"\nCompany with ID: {id} not found!\n");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.Clear();
                var message = CustomExceptions.CustomException(e);
                foreach (var item in message)
                {
                    Console.WriteLine($"{item}\n");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }            
            Console.Clear();
            List();
        }

        public override void Update()
        {
            CustomerLogic customerLogic = new CustomerLogic();
            var valid = new Validation();
            string input = null;
            string companyName = null;
            string contactName = null;

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nEnter a number ID:\n");
                input = Console.ReadLine();
                if (valid.IsValidString(input))
                {
                    exit = valid.IsValidString(input);
                }
                Console.Clear();
            }
            var id = input;
            try
            {
                var customerUpdate = customerLogic.GetOneString(id);
                if (customerUpdate != null)
                {
                    exit = false;
                    while (!exit)
                    {
                        Console.WriteLine("\nEnter a Company Name (max 40 characters):\n");
                        input = Console.ReadLine();
                        if (valid.NameLong(input, 40))
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
                        if (valid.NameLong(input, 30))
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
                        customerLogic.Update(new Customers
                        {
                            CustomerID = customerUpdate.CustomerID,
                            CompanyName = companyName,
                            ContactName = contactName,
                        });
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        var message = CustomExceptions.CustomException(e);
                        foreach (var item in message)
                        {
                            Console.WriteLine($"{item}\n");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine($"Category with ID: '{id}' not found!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            catch (InvalidOperationException e)
            {
                Console.Clear();
                var message = CustomExceptions.CustomInvalidOperationException(e);
                foreach (var item in message)
                {
                    Console.WriteLine($"{item}\n");
                }
                Console.WriteLine($"\nCompany with ID: '{id}' not found!\n");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            Console.Clear();
            List();
        }
    }
}
