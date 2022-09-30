using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.EF.Entities
{
    public class CustomersOrders
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public int OrderID { get; set; }
    }
}
