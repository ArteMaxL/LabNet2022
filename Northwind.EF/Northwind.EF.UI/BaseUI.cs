using Northwind.Linq.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Linq.UI
{
    public abstract class BaseUI
    {
        protected readonly CustomerLogic _customerLogic;
        protected readonly ProductLogic _productLogic;

        public BaseUI()
        {
            _customerLogic = new CustomerLogic();
            _productLogic = new ProductLogic();
        }
    }
}
