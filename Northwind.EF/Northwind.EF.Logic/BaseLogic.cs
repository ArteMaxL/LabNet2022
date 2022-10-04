using Northwind.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.EF.Logic
{
    public abstract class BaseLogic<T> : ICRUDLogic<T>
    {
        protected readonly NorthwindContext _context;

        public BaseLogic()
        {
            _context = new NorthwindContext();
        }

        public abstract void Add(T newT);

        public abstract void Delete(int id);

        public abstract IQueryable<T> GetAll();

        public abstract T GetOne(int id);

        public abstract void Update(T updateT);
    }
}
