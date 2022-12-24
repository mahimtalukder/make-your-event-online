using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class ServiceRepo: Repo, IRepo<Service, int, Service>
    {
        public Service Add(Service obj)
        {
            db.Services.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var DBService = Get(id);
            db.Services.Remove(DBService);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Service> Get()
        {
            return db.Services.ToList();
        }

        public Service Get(int id)
        {
            var DBService = db.Services.SingleOrDefault(x => x.Id == id);
            if (DBService != null)
            {
                return DBService;
            }
            return null;
        }

        public Service Update(Service obj)
        {
            var DBService = Get(obj.Id);
            db.Entry(DBService).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
            throw new NotImplementedException();
        }
    }
}
