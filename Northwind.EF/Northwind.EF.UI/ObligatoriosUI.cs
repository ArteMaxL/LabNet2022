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

namespace Northwind.Linq.UI
{
    public class ObligatoriosUI : BaseUI
    {
        public void Ejercicio1()
        {            
            Console.WriteLine();
            var valid = new Validation();
            string id = "";

            bool exit = false;
            while (!exit)
            {
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
    }
}
