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
    internal class ShipperUI : UIBase
    {

        public override void List()
        {
            ShipperLogic shipperLogic = new ShipperLogic();
            var shippers = shipperLogic.GetAll();

            foreach (Shippers shipper in shippers)
            {
                Console.WriteLine($"ID: {shipper.ShipperID}\tCompany Name: {shipper.CompanyName}");
                Console.WriteLine($"Company Phone: {shipper.Phone}");
                Console.WriteLine("-------------------------------------------------");
            }
            Console.WriteLine($"{System.Environment.NewLine}===Press any key to continue===");
            Console.ReadKey();
        }

        public override void Add()
        {
            ShipperLogic shipperLogic = new ShipperLogic();
            var valid = new Validation();
            var shippers = shipperLogic.GetAll();
            int quantity = shippers.Count() + 1;
            string input = null;
            string inputName = null;
            string phone = null;

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nEnter a Company Name (max 40 characters):\n");
                input = Console.ReadLine();
                if (valid.NameLong(input, 40))
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

            exit = false;
            while (!exit)
            {
                Console.WriteLine("\nEnter a Company Phone (max 24 characters):\n");
                input = Console.ReadLine();
                if (valid.NameLong(input, 24))
                {
                    phone = input;
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Phone number too long!.");
                    Thread.Sleep(1500);
                }
                Console.Clear();
            }

            try
            {
                shipperLogic.Add(new Shippers
                {
                    ShipperID = quantity,
                    CompanyName = inputName,
                    Phone = phone,
                });

                Console.WriteLine("Shipper added!\n");
                Console.WriteLine("Press any key to continue...");
                Console.WriteLine("\n======================\n");
                Console.ReadKey();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                Console.Clear();
                var message = ExtensionMethods.DbEntityValidation(e);
                Console.WriteLine($"{message}\n");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.Clear();
                var message = ExtensionMethods.CustomException(e);
                Console.WriteLine($"{message}\n");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            Console.Clear();
            List();
        }

        public override void Delete()
        {
            ShipperLogic shipperLogic = new ShipperLogic();
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
            var shipperDelete = shipperLogic.GetOne(id);

            if (shipperDelete != null)
            {
                try
                {
                    shipperLogic.Delete(shipperDelete.ShipperID);
                    Console.WriteLine("Shipper to be deleted:\n");
                    Console.WriteLine($"ID: {shipperDelete.ShipperID}\tCompany Name: {shipperDelete.CompanyName}");
                    Console.WriteLine($"Company Phone: {shipperDelete.Phone}");
                    Console.WriteLine("Press any key to continue...");
                    Console.WriteLine("\n======================\n");
                    Console.ReadKey();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                {
                    Console.Clear();
                    var message = ExtensionMethods.CustomDbUpdateException(e);
                    Console.WriteLine($"{message}\n");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.Clear();
                    var message = ExtensionMethods.CustomException(e);
                    Console.WriteLine($"{message}\n");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine($"Shipper with ID: {id} not found!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            Console.Clear();
            List();
        }

        public override void Update()
        {
            ShipperLogic shipperLogic = new ShipperLogic();
            var valid = new Validation();
            string input = null;
            string inputName = null;
            string phone = null;

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
            var shipperUpdate = shipperLogic.GetOne(id);

            if (shipperUpdate != null)
            {
                exit = false;
                while (!exit)
                {
                    Console.WriteLine("\nEnter a Company Name (max 40 characters):\n");
                    input = Console.ReadLine();
                    if (valid.NameLong(input, 40))
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

                exit = false;
                while (!exit)
                {
                    Console.WriteLine("\nEnter a Company Phone (max 24 characters):\n");
                    input = Console.ReadLine();
                    if (valid.NameLong(input, 24))
                    {
                        phone = input;
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("Phone number too long!.");
                        Thread.Sleep(1500);
                    }
                    Console.Clear();
                }

                try
                {
                    shipperLogic.Update(new Shippers
                    {
                        ShipperID = shipperUpdate.ShipperID,
                        CompanyName = inputName,
                        Phone = phone,
                    });
                }
                catch (Exception e)
                {
                    Console.Clear();
                    var message = ExtensionMethods.CustomException(e);
                    Console.WriteLine($"{message}\n");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine($"Shipper with ID: {id} not found!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            Console.Clear();
            List();
        }
    }
}
