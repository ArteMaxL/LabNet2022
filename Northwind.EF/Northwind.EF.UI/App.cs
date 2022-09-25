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
            {
                Console.Clear();
                Console.WriteLine("╔═══════════════════════╗");
                Console.WriteLine("║=======Main Menu=======║");
                Console.WriteLine("╠═══════════════════════╣");
                Console.WriteLine("║ 1 - Categories.       ║");
                Console.WriteLine("╠═══════════════════════╣");
                Console.WriteLine("║ 2 - Customers.        ║");
                Console.WriteLine("╠═══════════════════════╣");
                Console.WriteLine("║ 3 - Shippers.         ║");
                Console.WriteLine("╠═══════════════════════╣");
                Console.WriteLine("║ 0 - Exit.             ║");
                Console.WriteLine("╚═══════════════════════╝");
                Console.Write("\nChoice: ");

                var choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        CategoriesMenu();
                        break;
                    case "2":
                        CustomersMenu();
                        break;
                    case "3":
                        ShippersMenu();
                        break;
                    case "0":
                        Console.WriteLine("\n===========End Program=============");
                        Thread.Sleep(1500);
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
                Console.WriteLine("╔════════════════════════════════╗");
                Console.WriteLine("║===========Categories===========║");
                Console.WriteLine("╠════════════════════════════════╣");
                Console.WriteLine("║ 1 - Add New.                   ║");
                Console.WriteLine("╠════════════════════════════════╣");
                Console.WriteLine("║ 2 - Update (Name, Description).║");
                Console.WriteLine("╠════════════════════════════════╣");
                Console.WriteLine("║ 3 - Delete (ID).               ║");
                Console.WriteLine("╠════════════════════════════════╣");
                Console.WriteLine("║ 4 - List.                      ║");
                Console.WriteLine("╠════════════════════════════════╣");
                Console.WriteLine("║ 0 - Back to Main Menu.         ║");
                Console.WriteLine("╚════════════════════════════════╝");
                Console.Write("\nChoice: ");

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

        private static void CustomersMenu() // TODO
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t====Customers====\n");
                Console.WriteLine("1 - Add New.");
                Console.WriteLine("2 - Update (Company Name, Contact Name).");
                Console.WriteLine("3 - Delete (ID).");
                Console.WriteLine("4 - List.");
                Console.WriteLine("0 - Back to Main Menu.");

                var choice = Console.ReadLine();
                Console.Clear();

                var UI = new CustomerUI();
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
        private static void ShippersMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t====Shippers====\n");
                Console.WriteLine("1 - Add New.");
                Console.WriteLine("2 - Update (Company Name, Phone).");
                Console.WriteLine("3 - Delete (ID).");
                Console.WriteLine("4 - List.");
                Console.WriteLine("0 - Back to Main Menu.");

                var choice = Console.ReadLine();
                Console.Clear();

                var UI = new ShipperUI();
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
    }
}
