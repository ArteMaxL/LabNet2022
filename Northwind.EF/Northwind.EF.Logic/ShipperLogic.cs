using Northwind.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.EF.Logic
{
    public class ShipperLogic : BaseLogic<Shippers>
    {
        public override void Add(Shippers shipper)
        {
            try
            {
                _context.Shippers.Add(shipper);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override void Delete(int id)
        {
                var shipper = _context.Shippers.Find(id);
                _context.Shippers.Remove(shipper);

                _context.SaveChanges();
        }

        public override IQueryable<Shippers> GetAll()
        {
            try
            {
                return _context.Shippers;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override Shippers GetOne(int id)
        {
            try
            {
                return _context.Shippers.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override void Update(Shippers shipperNew)
        {
            try
            {
                var shipperUpdate = _context.Shippers.Find(shipperNew.ShipperID);

                shipperUpdate.CompanyName = shipperNew.CompanyName;
                shipperUpdate.Phone = shipperNew.Phone;

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
