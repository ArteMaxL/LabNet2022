using Northwind.EF.Entities;
using Northwind.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.EF.UI
{
    public class App
    {
        public App(){}

        public void MainMenu()
        {
            Start();
        }
        private static void Start()
        {
            while (true)
            { // Categories - Customers - Shippers
                Console.Clear();
                Console.WriteLine("\t====Main Menu====\n");
                Console.WriteLine("1 - Categories.");
                Console.WriteLine("2 - Employees.");
                Console.WriteLine("0 - Exit.");

                var choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        CategoriesMenu();
                        break;
                    case "2":
                        EmployeesMenu();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void CategoriesMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t====Categories====\n");
                Console.WriteLine("1 - Add.");
                Console.WriteLine("2 - Update (Name, Description).");
                Console.WriteLine("3 - Delete (ID).");
                Console.WriteLine("4 - List.");
                Console.WriteLine("0 - Back to Main Menu.");

                var choice = Console.ReadLine();
                Console.Clear();

                var UI = new CategoryUI();
                switch (choice)
                {
                    case "1":
                        UI.Add();
                        break;
                    case "2":
                        UI.Update();
                        break;
                    case "3":
                        UI.Delete();
                        break;
                    case "4":
                        UI.List();
                        break;
                    case "0":
                        Start();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void EmployeesMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1* Add.");
                Console.WriteLine("2* Update (First name).");
                Console.WriteLine("3* Delete.");
                Console.WriteLine("4* List.");
                Console.WriteLine("0* Back to Main Menu.");
                var choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        // Add();
                        break;
                    case "2":
                        // Update();
                        break;
                    case "3":
                        // Delete();
                        break;
                    case "4":
                        // GetList();
                        break;
                    case "0":
                        Start();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
