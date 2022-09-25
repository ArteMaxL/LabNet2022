using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.EF.UI
{
    public abstract class UIBase
    {
        public abstract void Add();

        public abstract void Delete();

        public abstract void List();

        public abstract void Update();
    }
}
