using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Linq.Entities
{
    public class CustomersOrders
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public int QuantityOrders { get; set; }
    }
}
