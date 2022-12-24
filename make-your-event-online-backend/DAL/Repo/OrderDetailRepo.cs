using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class OrderDetailRepo : Repo, IRepo<OrderDetail, int, OrderDetail>
    {
        public OrderDetail Add(OrderDetail obj)
        {
            db.OrderDetails.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var DBOrderDetail = Get(id);
            db.OrderDetails.Remove(DBOrderDetail);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<OrderDetail> Get()
        {
            return db.OrderDetails.ToList();
        }

        public OrderDetail Get(int id)
        {
            var DBOrderDetail = db.OrderDetails.SingleOrDefault(x => x.Id == id);
            if (DBOrderDetail != null)
            {
                return DBOrderDetail;
            }
            return null;
        }

        public OrderDetail Update(OrderDetail obj)
        {
            var DBOrderDetail = Get(obj.Id);
            db.Entry(DBOrderDetail).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
            throw new NotImplementedException();
        }
    }
}
