using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class CustomerRepo : Repo, IRepo<Customer, int, Customer>
    {
        public Customer Add(Customer obj)
        {
            db.Customers.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            db.Customers.Remove(db.Customers.SingleOrDefault(x => x.Id == id));
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Customer> Get()
        {
            return db.Customers.ToList();
        }

        public Customer Get(int id)
        {
            var DBUser = db.Customers.SingleOrDefault(x => x.Id == id);
            if (DBUser != null)
            {
                return DBUser;
            }
            return null;
        }

        public Customer Update(Customer obj)
        {
            var DBUser = Get(obj.Id);
            db.Entry(DBUser).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
