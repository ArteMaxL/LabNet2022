﻿using Northwind.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.EF.Logic
{
    public interface ICRUDLogic<T>
    {
        List<T> GetAll();
        T GetOne(int id);
        void Add(T newT);
        void Delete(int id);
        void Update(T updateT);
    }
}
