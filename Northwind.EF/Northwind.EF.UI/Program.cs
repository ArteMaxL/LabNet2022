using Northwind.EF.Entities;
using Northwind.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.EF.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var app = new App();
            app.MainMenu();
        }
    }
}
