using Northwind.Linq.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Linq.Logic
{
    public class ShipperLogic : BaseLogic<Shippers>
    {
        public override void Add(Shippers shipper)
        {
            _context.Shippers.Add(shipper);
            _context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var shipper = _context.Shippers.Find(id);
            _context.Shippers.Remove(shipper);

            _context.SaveChanges();
        }

        public override List<Shippers> GetAll()
        {
            return _context.Shippers.ToList();
        }

        public override Shippers GetOne(int id)
        {
            return _context.Shippers.Find(id);
        }

        public override void Update(Shippers shipperNew)
        {
            var shipperUpdate = _context.Shippers.Find(shipperNew.ShipperID);

            shipperUpdate.CompanyName = shipperNew.CompanyName;
            shipperUpdate.Phone = shipperNew.Phone;

            _context.SaveChanges();
        }
    }
}
