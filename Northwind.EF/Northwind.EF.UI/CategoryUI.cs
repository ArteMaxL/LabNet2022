using Northwind.EF.Common;
using Northwind.EF.Entities;
using Northwind.EF.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.EF.UI
{
    public class CategoryUI : UIBase
    {
        public override void List()
        {
            CategoryLogic categoryLogic = new CategoryLogic();
            var categories = categoryLogic.GetAll();

            foreach (Categories category in categories)
            {
                Console.WriteLine($"ID: {category.CategoryID}\tCategory Name: {category.CategoryName}");
                Console.WriteLine($"Category Description: {category.Description}");
                Console.WriteLine("-------------------------------------------------");
            }
            Console.WriteLine($"{System.Environment.NewLine}===Press any key to continue===");
            Console.ReadKey();
        }

        public override void Add()
        {
            CategoryLogic categoryLogic = new CategoryLogic();
            var valid = new Validation();
            var categories = categoryLogic.GetAll();
            int quantity = categories.Count() + 1;
            string input = null;
            string inputName = null;
            string description = null;

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nEnter a Category Name (max 15 characters):\n");
                input = Console.ReadLine();
                if (valid.NameLong(input, 15))
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
                categoryLogic.Add(new Categories
                {
                    CategoryID = quantity,
                    CategoryName = inputName,
                    Description = description,
                });

                Console.WriteLine("Category added!\n"); 
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

            if (categoryDelete != null) {
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
                Console.WriteLine($"Category with ID: {id} not found!" );
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
                    if (valid.NameLong(input, 15))
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
                    Console.Clear();
                    var message = ExtensionMethods.CustomException(e);
                    Console.WriteLine($"{message}\n");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
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
