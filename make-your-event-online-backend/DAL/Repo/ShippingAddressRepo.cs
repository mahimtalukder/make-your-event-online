using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class ShippingAddressRepo : Repo, IRepo<ShippingAddress, int, ShippingAddress>
    {
        public ShippingAddress Add(ShippingAddress obj)
        {
            db.ShippingAddresses.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ship = Get(id);
            db.ShippingAddresses.Remove(ship);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public List<ShippingAddress> Get()
        {
            return db.ShippingAddresses.ToList();
        }

        public ShippingAddress Get(int id)
        {
            return db.ShippingAddresses.Find(id);
        }

        public ShippingAddress Update(ShippingAddress obj)
        {
            var ship = Get(obj.Id);
            db.Entry(ship).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
