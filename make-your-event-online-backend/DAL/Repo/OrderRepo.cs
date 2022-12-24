using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class OrderRepo : Repo, IRepo<Order, int, Order>
    {
        public Order Add(Order obj)
        {
            db.Orders.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var DBOrder = Get(id);
            db.Orders.Remove(DBOrder);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Order> Get()
        {
            return db.Orders.ToList();
        }

        public Order Get(int id)
        {
            var DBOrder = db.Orders.SingleOrDefault(x => x.Id == id);
            if (DBOrder != null)
            {
                return DBOrder;
            }
            return null;
        }

        public Order Update(Order obj)
        {
            var DBOrder = Get(obj.Id);
            db.Entry(DBOrder).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
            throw new NotImplementedException();
        }
    }
}
