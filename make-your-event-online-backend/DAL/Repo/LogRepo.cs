using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class LogRepo : Repo, IRepo<Log, int, Log>
    {
        public Log Add(Log obj)
        {
            db.Logs.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var log = Get(id);
            db.Logs.Remove(log);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public List<Log> Get()
        {
            return db.Logs.ToList();
        }

        public Log Get(int id)
        {
            return db.Logs.Find(id);
        }

        public Log Update(Log obj)
        {
            var log = Get(obj.Id);
            db.Entry(log).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
