using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class LocationRepo : Repo, IRepo<Location, int, Location>
    {
        public Location Add(Location obj)
        {
            db.Locations.Add(obj);
            if(db.SaveChanges()>0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var data = Get(id);
            db.Locations.Remove(data);
            if(db.SaveChanges()>0) return true; 
            return false;
        }

        public List<Location> Get()
        {
            return db.Locations.ToList();
        }

        public Location Get(int id)
        {
            var DbLoaction = db.Locations.SingleOrDefault(x => x.Id == id);
            if (DbLoaction != null)
            {
                return DbLoaction;
            }
            return null;
        }

        public Location Update(Location obj)
        {
            var DbLocation = Get(obj.Id);
            db.Entry(DbLocation).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return obj;
        }
    }
}
